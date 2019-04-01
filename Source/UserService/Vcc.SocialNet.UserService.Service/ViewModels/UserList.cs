using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.ViewModels
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserList : System.Collections.ObjectModel.Collection<User>
    {
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static UserList FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserList>(data);
        }

    }

}
