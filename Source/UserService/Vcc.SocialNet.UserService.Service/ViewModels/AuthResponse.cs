using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Common;

namespace Vcc.SocialNet.UserService.Service.ViewModels
{  
    /// <summary>
    /// Represent a response object for authenticating a user
    /// </summary>        
    public partial class AuthResponse
    {   
        /// <summary>
        /// Jwt authentication token 
        /// </summary>
        public string Token { get; set; }
        // Indicates if authentication was successful
        public bool Success{ get; set; }        
    }
}
