using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using OrionTM_Web.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace OrionTM_Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl

            });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null && loginVM.Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVM.ReturnUrl);

                }
            }

            ModelState.AddModelError("", "Falha ao realizar o login!!");
            return View(loginVM);
        }



        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();

        }

        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }



        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.UserName };
                user.Email = registroVM.Email;
                user.PhoneNumber = registroVM.PhoneNumber;

                if (registroVM.Password != registroVM.PasswordConf)
                {

                    ModelState.AddModelError("Aviso", "Senha não confere!!!!");
                    return View(registroVM);

                }

                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    if (registroVM.IsAdm == true)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Usuario");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }

            return View(registroVM);

        }

     

        public IActionResult setlanguage(string culture)

        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMonths(6)
                });

            return RedirectToActionPreserveMethod("Login");

        }



    }
}