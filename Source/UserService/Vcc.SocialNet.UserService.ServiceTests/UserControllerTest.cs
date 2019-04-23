using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vcc.SocialNet.UserService.Data.Repository;
using Vcc.SocialNet.UserService.Service.Controllers;
using System.Linq;
using Vcc.SocialNet.UserService.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Vcc.SocialNet.UserService.Service.ViewModels;
using Vcc.SocialNet.UserService.Service.MapProfile;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace Vcc.SocialNet.UserService.ServiceTests
{
    [TestClass]
    public class UserControllerTest
    {
        Mock<IMemberRepository> _mockRepo;
        Mock<ILogger<UserController>> _mockLogger;
        Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IMemberRepository>();        
            _mockLogger = new Mock<ILogger<UserController>>();
            _mockMapper = new Mock<IMapper>();
           
            // if we want to test the real mapper profile, set up the Imapper object using the profile
            //var mapProfile = new UserMapProfile();
            //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
            //var mockMapper = new Mapper(configuration);

        }

        [TestMethod]
        public async Task ShowUserByIdTest()
        {
            // Arrange            
            // set up a mock repository created by Moq to return a mock entity
            _mockRepo
                .Setup(repo => repo.GetMemberByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int i) =>
                {
                    return new MemberEntity()
                    { Id = i, FirstName = "FirstTest", LastName = "LastTest"};
                });
            //.ReturnsAsync(new MemberEntity() { Id = id });
            _mockMapper.Setup(x => x.Map<User>(It.IsAny<MemberEntity>()))
               .Returns((MemberEntity source) =>
               {
                    // abstract mapping function code here, return instance of DestinationClass
                   return new User()
                   {
                       Id = source.Id,
                       FirstName = source.FirstName,
                       LastName = source.LastName
                   };
               });

            var controller = new UserController(_mockRepo.Object, _mockMapper.Object, _mockLogger.Object);

            // Act
            var testId = 1;
            var result = await controller.ShowUserById(testId);

            // Assert
            Assert.IsTrue(result != null && result.Result != null);
            Assert.IsTrue(result.Result is OkObjectResult && ((OkObjectResult)result.Result).Value is User);
            var actual = ((OkObjectResult)result.Result).Value as User;
            Assert.AreEqual(testId, actual.Id);
        }

        /// <summary>
        /// Test method that tests ShowUserByID method of UserController class
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// This test method utilizes Moq, AutoFixture.AutoMoq, AutoFixture.MSTest NuGet packages.
        /// Even if a new Dependecy is added to the constructor of UserController class, no change 
        /// is required for ShowUserByIdTest_AutoFixture method as Moq and AutoFixture will detect the new dependency
        /// and will inject an instance for the new dependency type when creating a SUT object.
        /// On the contrary, ShowUserByIdTest method will start breaking due to the change in the constructor.
        /// </remarks>
        [TestMethod]
        public async Task ShowUserByIdTest_AutoFixture()
        {
            // Arrange            
            // set up a mock repository created by Moq and AutoFixture to return a mock entity
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var member = fixture.Create<MemberEntity>();
            // freeze the mock for IMemberRepository & IMapper so that the same mock instances 
            // that has been specifically set up will always be used when creating the SUT object 
            // instead of a brand new instance without the required setup
            var mockRepoFix = fixture.Freeze<Mock<IMemberRepository>>();
            var mockMapper = fixture.Freeze<Mock<IMapper>>();
            mockRepoFix.Setup(repo => repo.GetMemberByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int i) =>
                {   
                    member.Id = i;
                    return member;
                    //{ Id = i, FirstName = "FirstTest", LastName = "LastTest" };
                });
                        
            mockMapper.Setup(x => x.Map<User>(It.IsAny<MemberEntity>()))
               .Returns((MemberEntity source) =>
               {
                   // abstract mapping function code here, return instance of DestinationClass
                   return new User()
                   {
                       Id = source.Id,
                       FirstName = source.FirstName,
                       LastName = source.LastName
                   };
               });

            // create a SUT object using Moq/autofixture
            // When creating a SUT object, autofix/Moq will inject the same mock instances 
            // that have been set up earlier to the consturctor of SUT object.
            var controller = fixture.Create<UserController>();
            // Act
            var testId = fixture.Create<int>();
            var result = await controller.ShowUserById(testId);

            // Assert
            Assert.IsTrue(result != null && result.Result != null);
            Assert.IsTrue(result.Result is OkObjectResult && ((OkObjectResult)result.Result).Value is User);
            var actual = ((OkObjectResult)result.Result).Value as User;
            // User object returned from API should contain the same Id value
            Assert.AreEqual(testId, actual.Id);
        }

        #region Mock functions
        private MemberEntity mock_GetMemberById()
        {
            var member = new MemberEntity();
            //{
            //    Address = ,
            //    CellPhone = ,
            //    City = ,
            //    DateOfBirth = ,
            //    Email = ,
            //    FirstName = ,
            //    Gender = ,
            //    HomePhone = ,
            //    Id = ,
            //    LastName = ,
            //    Position = ,
            //    PostalCode = ,
            //    Province
            //};
            return member;
        }
        #endregion
    }
}
