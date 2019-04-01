using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.ViewModels
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Error
    {
        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Always)]
        public int Code { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Error FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(data);
        }

    }
}
