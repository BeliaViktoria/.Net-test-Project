using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace testProject.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService userService;

        private readonly ILogger<AuthorizationController> logger;

        public AuthorizationController(ILogger<AuthorizationController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    int userId = this.userService.AuthorizeUser(login, password);
                    this.logger.LogInformation("Authorization succeded");
                    return this.RedirectToAction("OrdersList", "Order", new { userId });
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Authorization failed");
                }
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string password)
        {
            if (this.ModelState.IsValid && user.Password.Equals(password))
            {
                try
                {
                    int userId = this.userService.RegisterUser(user);
                    this.logger.LogInformation("Registration succeded");
                    return this.RedirectToAction("OrdersList", "Order", new { userId });
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Registration failed");
                }
            }

            return this.View();
        }
    }
}
