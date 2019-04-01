using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Data.Entities;
using Vcc.SocialNet.UserService.Service.ViewModels;

namespace Vcc.SocialNet.UserService.Service.MapProfile
{
    /// <summary>
    /// Configuration class for mapping User view model objects
    /// </summary>
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<User, MemberEntity>();
        }
    }
}
