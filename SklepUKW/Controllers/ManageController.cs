using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SklepUKW.App_Start;
using SklepUKW.Models;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            ChangeUserDataSuccess,
            ValidationError,
            Error
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Hasło zmieniono pomyślnie"
                : message == ManageMessageId.Error ? "Wystąpił błąd"
                : message == ManageMessageId.ChangeUserDataSuccess ? "Dane użytkownika zmieniono pomyślnie"
                : message == ManageMessageId.ValidationError ? "Błąd walidacji"
                : "";

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var model = new ManageViewModel
            {
                Message = message,
                UserData = user.UserData
            };
            return View(model);
        }

        /// <summary>
        /// Sprawdzić metodę ChangePassword i dopisać ChangeUserData
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ManageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.ValidationError });
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.ChangePasswordViewModel.OldPassword, model.ChangePasswordViewModel.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUserData(ManageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.ValidationError });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            user.UserData = model.UserData;
            var result = await UserManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangeUserDataSuccess });

            }
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}