using Library.Domain.Models.Identity;
using Library.Service.DTOs.Account;
using Library.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginUserDTO login)
        {
            var user = await _userService.Login(login.Mobile);
            if (!user.Success)
            {
                ModelState.AddModelError(string.Empty, user.Message);
                return View(login);
            }

            var signIn = await _signInManager.PasswordSignInAsync(user.Data, login.Password, login.RememberMe, false);
            if (!signIn.Succeeded)
            {
                ModelState.AddModelError(string.Empty, user.Message);
                return View(login);
            }

            return Redirect("/");
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerUser);
                if (result.Success)
                    return RedirectToAction("Login");

                foreach (var err in result.Data)
                {
                    ModelState.AddModelError(string.Empty, err);
                }

            }


            return View(registerUser);
        }
    }
}
