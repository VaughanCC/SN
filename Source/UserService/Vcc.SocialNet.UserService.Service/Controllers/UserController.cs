using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Data.Entities;
using Vcc.SocialNet.UserService.Data.Repository;
using Vcc.SocialNet.UserService.Service.Attributes;
using Vcc.SocialNet.UserService.Service.ViewModels;

namespace Vcc.SocialNet.UserService.Service.Controllers
{
    /// <summary>
    /// Api controller that provide user related operations
    /// </summary>
    public class UserController : ApiControllerBase
    {       
        private readonly ILogger<UserController> _logger;
        private IMemberRepository _repo;
        private IMapper _mapper;
        protected override string ClassName
        {
            get { return "UserController"; }
        }
        protected override ILogger Logger
        {
            get { return _logger; }
        }


        public UserController(
            IMemberRepository memberRepository, 
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _repo = memberRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Info for a specific user
        /// </summary>
        /// <param name="userId">The id of the user to retrieve</param>
        /// <response code="200">Expected response to a valid request</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [ApiVersionNeutral]
        [Route("users/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("ShowUserById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "Expected response to a valid request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public async virtual Task<ActionResult<User>> ShowUserById([FromRoute][Required]int userId)
        {
            LogEnter("ShowUserById", userId);

            ActionResult<User> result;
            MemberEntity member = await _repo.GetMemberByIdAsync(userId);
            if (member != null)
            {
                User userViewModel = _mapper.Map<User>(member);
                result =  Ok(userViewModel);
            }
            else
            {
                result =  NotFound();
            }

            LogExit("ShowUserById", result);
            return result;
        }

        /// <summary>
        /// Info for a specific user
        /// </summary>
        /// <param name="userId">The id of the user to retrieve</param>
        /// <response code="200">Expected response to a valid request</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("users/email/{email}")]
        [ValidateModelState]
        [SwaggerOperation("ShowUserByEmail")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "Expected response to a valid request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public async virtual Task<ActionResult<User>> ShowUserByEmail([FromRoute][Required]string email)
        {
            LogEnter("ShowUserByEmail", email);

            ActionResult<User> result;
            MemberEntity member = await _repo.GetMemberByEmailAsync(email);
             if (member != null)
            {
                User userViewModel = _mapper.Map<User>(member);
                result = Ok(userViewModel);
            }
            else
            {
                result = NotFound();
            }

            LogExit("ShowUserById", result);
            return result;
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <param name="limit">How many items to return at one time (max 100)</param>
        /// <response code="200">A paged array of users</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("users")]
        [ValidateModelState]
        [SwaggerOperation("ListUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "A paged array of users")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public async virtual Task<ActionResult<IEnumerable<User>>> ListUser([FromQuery]int? limit)
        {
            LogEnter("ListUser", limit);
            ActionResult<IEnumerable<User>> result;

            var members = await _repo.GetMembersAsync();
            if (members != null)
            {
                IEnumerable<User> list = _mapper.Map<IEnumerable<MemberEntity>, IEnumerable<User>>(members);
                result = Ok(list);
            }
            else
            {
                result = NotFound();
            }
            LogExit("ListUser", result);
            return result;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [Route("users")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 201, type: typeof(User), description: "A user created newly")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual async Task<IActionResult> CreateUser([FromBody] User user)
        {
            LogEnter("CreateUser", user);
            IActionResult result;
            if (TryValidateModel(user))
            {
                MemberEntity member = _mapper.Map<MemberEntity>(user);
                if(member != null)
                {
                    var newMember = await _repo.CreateMemberAsync(member);
                    result = CreatedAtAction(nameof(ShowUserById), new { id = newMember.Id });
                }
                else
                {
                    result = BadRequest();
                }
            }
            else
            {
                result = BadRequest();
            }
            LogExit("CreateUser", result);
            return result;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpPut]
        [Route("users/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "A user updated")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual async Task<IActionResult> UpdateUser([FromBody] User user, [FromRoute] int userId)
        {
            LogEnter("CreateUser", user);
            IActionResult result;
            if (TryValidateModel(user))
            {
                MemberEntity member = _mapper.Map<MemberEntity>(user);
                if (member != null)
                {
                    var newMember = await _repo.CreateMemberAsync(member);
                    result = Ok();
                }
                else
                {
                    result = BadRequest();
                }
            }
            else
            {
                result = BadRequest();
            }
            LogExit("UpdateUser", result);
            return result;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpPatch]
        [Route("users/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("PatchUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "A user updated")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual async Task<ActionResult<User>> PatchUser([FromRoute] int userId, [FromBody] JsonPatchDocument<User> userPatch)
        {
            LogEnter("PatchUser", userId, userPatch);
            ActionResult<User> result;
            if (userId > 0 && userPatch != null)
            {
                MemberEntity member = await _repo.GetMemberByIdAsync(userId);
                if (member != null)
                {
                    var userLoaded = _mapper.Map<User>(member);
                    userPatch.ApplyTo(userLoaded);
                    member = _mapper.Map<MemberEntity>(userLoaded);
                    await _repo.UpdateMemberAsync(member);
                    result = Ok();
                }
                else
                {
                    result = NotFound();
                }
            }
            else
            {
                result = BadRequest();
            }
            LogExit("PatchUser", result);
            return result;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpDelete]
        [Route("users/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "A user deleted")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual async Task<ActionResult<User>> DeleteUser([FromRoute] int userId)
        {
            LogEnter("DeleteUser", userId);
            ActionResult<User> result;
            if (userId > 0 )
            {
                await _repo.DeleteMemberAsync(userId);
                result = Ok();
            }
            else
            {
                result = BadRequest();
            }
            LogEnter("DeleteUser", result);
            return result;
        }

        /// <summary>
        /// Summary info for a specific user
        /// </summary>
        /// <param name="userId">The id of the user to retrieve</param>
        /// <response code="200">Expected response to a valid request</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("users/{userId}")]
        [SwaggerOperation("ShowUserSummary")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<UserSummary>), description: "Expected response to a valid request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public async virtual Task<ActionResult<User>> ShowUserSummary([FromRoute][Required]int userId)
        {
            LogEnter("ShowUserById", userId);

            ActionResult<User> result;
            MemberEntity member = await _repo.GetMemberByIdAsync(userId);
            if (member != null)
            {
                User userViewModel = _mapper.Map<User>(member);
                result = Ok(userViewModel);
            }
            else
            {
                result = NotFound();
            }

            LogExit("ShowUserById", result);
            return result;
        }
    }
}
