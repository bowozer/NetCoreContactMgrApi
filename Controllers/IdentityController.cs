using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCoreContactMgrApi
{
    /// <summary>
    /// Part of identity client (API)
    /// </summary>
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var claimList = from claim in User.Claims
                            select new { claim.Type, claim.Value };
            return new JsonResult(claimList);
        }
    }
}
