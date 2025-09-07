using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Model.ViewModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace BlogApi.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class MonitorController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;

        public MonitorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public ResponseResult<ServerViewModel> Server()
        {
            return new ResponseResult<ServerViewModel>
            {
                message = "获取成功!",
                response = new ServerViewModel()
                {
                    EnvironmentName = _env.EnvironmentName,
                    OSArchitecture = JsonSerializer.Serialize(RuntimeInformation.OSArchitecture),
                    ContentRootPath = _env.ContentRootPath,
                    WebRootPath = _env.WebRootPath,
                    FrameworkDescription = RuntimeInformation.FrameworkDescription,
                    MemoryFootprint = (Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + " MB",
                    //WorkingTime = DateHelper.TimeSubTract(DateTime.Now, Process.GetCurrentProcess().StartTime)
                }
            };
        }


        public class WelcomeInitData
        {
            public List<ActiveUserVM> activeUsers { get; set; }
            public int activeUserCount { get; set; }
            public List<UserAccessModel> logs { get; set; }
            public int errorCount { get; set; }
            public List<ActiveUserVM> activeCount { get; set; }
        }

        public class ActiveUserVM
        {
            public string user { get; set; }
            public int count { get; set; }
        }

        public class UserAccessModel
        {
            public string User { get; set; }
            public string IP { get; set; }
            public string API { get; set; }
            public string BeginTime { get; set; }
            public string OPTime { get; set; }
            public string RequestMethod { get; set; }
            public string RequestData { get; set; }
            public string Agent { get; set; }
        }
    }
}
