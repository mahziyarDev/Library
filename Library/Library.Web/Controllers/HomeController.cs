using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
