using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class RoleController : AdminBaseController
    {
        [HttpGet("RoleManagement")]
        public IActionResult RoleManagement()
        {
            return View();
        }
    }
}
