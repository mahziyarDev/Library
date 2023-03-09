using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
