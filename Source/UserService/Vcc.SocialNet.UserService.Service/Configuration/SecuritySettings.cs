using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.Configuration
{
    public class SecuritySettings
    {
        public string AllowedOrigins { get; set; }
        public string AllowedHeaders { get; set; }
        public string AuthTokenSecret { get; set; }
    }
}
