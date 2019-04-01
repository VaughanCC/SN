using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vcc.SocialNet.UserService.Common;
using Vcc.SocialNet.UserService.Data.Entities;

namespace Vcc.SocialNet.UserService.Data
{
    /// <summary>
    /// Represent the DbConText for data related to User such as Member, Role, Authorization, etc.
    /// </summary>
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or Sets Members - a lit of Members
        /// </summary>
        public DbSet<MemberEntity> Members { get; set; }

        /// <summary>
        /// Overrides OnModelCreating to see initial data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEntity>().HasData(
                      new MemberEntity
                      {
                          Id = 1,
                          Address = "160 Borrows Street",
                          CellPhone = "4168493938",
                          City = "Toronto",
                          DateOfBirth = new DateTime(1972, 4, 16),
                          Email = "joon.choi@gmail.com",
                          FirstName = "Joon",
                          Gender = GenderEnum.Male,
                          HomePhone = "4169026859",
                          LastName = "Choi",
                          Position =  PositionEnum.Layman,
                          PostalCode = "L3J 2S9",
                          Province = "ON"
                      },
                      new MemberEntity
                      {
                          Id = 2,
                          Address = "160 Borrows Street",
                          CellPhone = "4168493938",
                          City = "Toronto",
                          DateOfBirth = new DateTime(1972, 4, 16),
                          Email = "joon.choi@gmail.com",
                          FirstName = "Joon2",
                          Gender = GenderEnum.Male,
                          HomePhone = "4169026859",
                          LastName = "Choi",
                          Position = PositionEnum.Layman,
                          PostalCode = "L3J 2S9",
                          Province = "ON"
                      }, new MemberEntity
                      {
                          Id = 3,
                          Address = "160 Borrows Street",
                          CellPhone = "4168493938",
                          City = "Toronto",
                          DateOfBirth = new DateTime(1972, 4, 16),
                          Email = "joon.choi@gmail.com",
                          FirstName = "Joon3",
                          Gender = GenderEnum.Male,
                          HomePhone = "4169026859",
                          LastName = "Choi",
                          Position = PositionEnum.Layman,
                          PostalCode = "L3J 2S9",
                          Province = "ON"
                      }, new MemberEntity
                      {
                          Id = 4,
                          Address = "160 Borrows Street",
                          CellPhone = "4168493938",
                          City = "Toronto",
                          DateOfBirth = new DateTime(1972, 4, 16),
                          Email = "joon.choi@gmail.com",
                          FirstName = "Joon4",
                          Gender = GenderEnum.Male,
                          HomePhone = "4169026859",
                          LastName = "Choi",
                          Position = PositionEnum.Layman,
                          PostalCode = "L3J 2S9",
                          Province = "ON"
                      }, new MemberEntity
                      {
                          Id = 5,
                          Address = "160 Borrows Street",
                          CellPhone = "4168493938",
                          City = "Toronto",
                          DateOfBirth = new DateTime(1972, 4, 16),
                          Email = "joon.choi@gmail.com",
                          FirstName = "Joon5",
                          Gender = GenderEnum.Male,
                          HomePhone = "4169026859",
                          LastName = "Choi",
                          Position = PositionEnum.Layman,
                          PostalCode = "L3J 2S9",
                          Province = "ON"
                      }
                  );
        }
    }
}
