using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;
using Student_Management_System.View_Models;

namespace Student_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signIn) { 
            this.userManager = user;
            this.signInManager = signIn;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM vm)
        {
            if (ModelState.IsValid)
            {
                //Mapping 
                ApplicationUser appUser = new ApplicationUser();

                appUser.UserName = vm.Username;
                appUser.PasswordHash = vm.Password;
                appUser.Address = vm.Address;
                appUser.Email = vm.Email;
                //save to database
                IdentityResult result = await userManager.CreateAsync(appUser, vm.Password);
                if (result.Succeeded)
                {
                    //Cookie
                    await signInManager.SignInAsync(appUser, isPersistent: false); 
                    return RedirectToAction("login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Register", vm);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //Check
                ApplicationUser? Appuser = await userManager.FindByNameAsync(userVM.username);
                if (Appuser != null)
                {
                    bool result = await userManager.CheckPasswordAsync(Appuser, userVM.Password);
                    if (result)
                    {
                        //Cookie
                        await signInManager.SignInAsync(Appuser, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "User Name or Passward are wrong");
            }
            return View("Login", userVM);
        }
        [HttpGet]
        public IActionResult signout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }

    }
}
