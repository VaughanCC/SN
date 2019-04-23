using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcc.SocialNet.UserService.Service.Controllers
{
    [ApiController()]
    [Route("api")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected virtual string ClassName
        {
            get { return "ApiControllerBase"; }
        }
        protected abstract ILogger Logger { get; }

        protected void LogEnter(string methodName, params object[] args)
        {
            try
            {
                string argStr = String.Join("|", (args != null) ? args : null);
                if (Logger.IsEnabled(LogLevel.Debug)) Logger.LogDebug($"Entering {ClassName}/{methodName} - {argStr}");
            }
            catch
            {
                // error logging is not working - continue
            }
        }

        protected void LogExit(string methodName, params object[] returnValues)
        {
            try
            {
                string returnValueStr = String.Join("|", (returnValues != null) ? returnValues : null);
                if (Logger.IsEnabled(LogLevel.Debug)) Logger.LogDebug($"Existing {ClassName}/{methodName} - {returnValueStr}");
            }
            catch
            {
                // error logging is not working - continue
            }
        }
    }
}
