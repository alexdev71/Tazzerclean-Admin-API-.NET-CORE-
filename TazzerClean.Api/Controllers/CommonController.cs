using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataContracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceContracts.Common;

namespace TazzerClean.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    [AllowAnonymous]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonManager _commonManager;
        public CommonController(ILogger<CommonController> logger, ICommonManager commonManager)
        {
            _logger = logger;
            _commonManager = commonManager;
        }

        [HttpGet]
        [Route("lookup/suburb")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PostalLookup>>> FindSuburb(string name)
        {
            try
            {
                var result = await _commonManager.FindSuburb(name);

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has been thrown in AuthController:Login");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("common/dashboard-stats")]
        [Authorize]
        public async Task<ActionResult<DashboardStats>> GetDashboardStats()
        {
            try
            {
                var result = await _commonManager.GetDashboardStats();

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has been thrown in CommonController:GetDashboardStats");
                return BadRequest(ex);
            }
        }
    }
}
