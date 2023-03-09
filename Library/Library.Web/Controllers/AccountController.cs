using Library.Service.DTOs.Account;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }
        

        [HttpPost("/Register")]
        public IActionResult Register(RegisterUserDTO registerUser)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}
