using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AppMVC_Net.Models;
using AmazonCloneMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppMVC_Net.Controllers
{
	public class AccessController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(VMLogin modelLogin)
		{
			if (modelLogin.Email == "user@example.com" && modelLogin.Password == "123")
			{
				// Authentification réussie pour un utilisateur
				List<Claim> claims = new List<Claim>()
		{
			new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
			new Claim("OtherProperties", "Exemple Role"),
			new Claim(ClaimTypes.Role, "User")
		};

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = modelLogin.KeepLoggedIn,
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

				return RedirectToAction("Index", "Home");
			}
			else if (modelLogin.Email == "admin@example.com" && modelLogin.Password == "admin123")
			{
				// Authentification réussie pour un administrateur
				List<Claim> claims = new List<Claim>()
		{
			new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
			new Claim("OtherProperties", "Exemple Role"),
			new Claim(ClaimTypes.Role, "Admin")  // Ajoutez le rôle "Admin"
        };

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = modelLogin.KeepLoggedIn,
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

				return RedirectToAction("Index", "Home");
			}

			ViewData["ValidateMessage"] = "User not found";
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
        public IActionResult AccessDenied()
        {
           
            return View();
        }

    }
}
