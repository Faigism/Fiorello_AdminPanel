using Fiorello_AdminPanel.Areas.Manage.ViewModels;
using Fiorello_AdminPanel.DAL;
using Fiorello_AdminPanel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_AdminPanel.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FiorelloDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager,FiorelloDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    return Content("created");
        //}
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                FullName = "SuperAdmin",
                UserName = "Fiko"
           };
            var result =  await _userManager.CreateAsync(admin, "Admin123");

            await _userManager.AddToRoleAsync(admin, "SuperAdmin");

            return Content("yaradildi");
        }
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLogin_VM adminVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser admin = await _userManager.FindByNameAsync(adminVM.UserName);
            if(admin == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(admin,adminVM.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("Index","Dashboard");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Register(AdminRegister_VM register_VM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FullName = register_VM.FullName,
                UserName = register_VM.UserName,
                Email = register_VM.Email
            };
            var result = await _userManager.CreateAsync(user,register_VM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult Admins()
        {
            List<AppUser> items = _context.AppUsers.ToList();
            return View(items);
        }
    }
}
