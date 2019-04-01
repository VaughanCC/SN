using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.ViewModels
{
    /// <summary>
    /// View model representing the user summary information
    /// </summary>
    public class UserSummary
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
