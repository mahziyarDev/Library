using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserIndex()
        {
            return View();
        }
    }
}
