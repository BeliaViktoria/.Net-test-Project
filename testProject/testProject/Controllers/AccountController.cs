using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testProject.Models;

namespace testProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        private readonly ILogger<AccountController> logger;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        public IActionResult Account(int userId)
        {
            try
            {
                var user = userService.GetUserById(userId);
                this.logger.LogInformation("Getting user info succeded");
                return this.View(user);
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("Getting user info failed");
                return this.Error();
            }
        }

        public IActionResult UpdateAccount(User user)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.userService.UpdateUser(user);
                    this.logger.LogInformation("Account updating succeded");
                    return this.RedirectToAction("OrdersList", "Order", new { userId = user.UserID });
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Account updating failed");
                }
            }

            return this.RedirectToAction("Account", "Account", new { userId = user.UserID });

        }

        public IActionResult DeleteAccount(User user)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.userService.DeleteUser(user);
                    this.logger.LogInformation("Account deleting succeded");
                    return this.RedirectToAction("Login", "Authorization");
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Account deleting failed");

                }
            }

            return this.RedirectToAction("Account", "Account", new { userId = user.UserID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}