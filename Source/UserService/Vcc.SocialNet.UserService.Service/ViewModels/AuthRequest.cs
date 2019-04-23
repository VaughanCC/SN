using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.ViewModels
{
    /// <summary>
    /// Represents Authentication request object
    /// </summary>
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
