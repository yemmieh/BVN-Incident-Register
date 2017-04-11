using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using BIW.Models;

using System.Web.Security;



public class AccountController : Controller
{
    public ActionResult Login()
    {
        ViewData["HopUser"] = false;
        ViewData["ICA"] = false;
        ViewData["Admin"] = false;
        return this.View();
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
        if (!this.ModelState.IsValid)
        {
            return this.View(model);
        }

        if (Membership.ValidateUser(model.Email, model.Password))
        {
            FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
            if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
            {
                return this.Redirect(returnUrl);
            }
            return this.RedirectToAction("Index", "Home");
        }
        this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
        ViewData["HopUser"] = false;
        ViewData["ICA"] = false;
        ViewData["Admin"] = false;
        return this.View(model);
    }

    public ActionResult LogOff()
    {
        FormsAuthentication.SignOut();
        ViewData["HopUser"] = false;
        ViewData["ICA"] = false;
        ViewData["Admin"] = false;

        return this.RedirectToAction("Index", "Home");
    }
}
