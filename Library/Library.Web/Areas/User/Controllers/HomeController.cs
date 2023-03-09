using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
