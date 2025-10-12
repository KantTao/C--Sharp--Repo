using BookManagementSystemAPI.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookManagementSystemAPI.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        //private IConfiguration _configuration;
        private AppInfo _appInfo;
        private ILogger<VersionController> _logger;
    
        public VersionController(IOptions<AppInfo> appInfo, ILogger<VersionController> logger)
        {
            // _configuration = _onfiguration;
            _appInfo = appInfo.Value;
            _logger = logger;
        }
        
        
        
        /// <summary>
        ///  Return AppInfo From configuration
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        /// <returns>Return AppInfo</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppInfo))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AppInfo> GetAppVersion()
        {
            //var  appVersion = _configuration.GetValue<int>("AppVersion");
            //return Ok(appVersion);
            
                _logger.LogInformation("Fetching AppInfo from appsettings......");

                var appVersion = _appInfo.AppVersion;
                if (_appInfo.AppVersion <= 0 || _appInfo.AppName == null)
                {
                    throw new InvalidOperationException("Failed to load appsettings,value null or empty");
                }
                
                return Ok(_appInfo);
            }
         
        

    }
}