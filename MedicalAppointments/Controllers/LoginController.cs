using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointments.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MedicalAppointments.Data;
using Microsoft.EntityFrameworkCore;
using MedicalAppointments.Data.ViewModels;

namespace MedicalAppointments.Controllers
{
    public class LoginController: Controller
    {
        /*rivate readonly ILogger<LoginController> _logger;

         public LoginController(ILogger<LoginController> logger)
         {
             _logger = logger;
         }
         public IActionResult Login()
         {
             return View();
         }

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
         {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }*/



        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly MedicalAppointmentsContext _context;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, MedicalAppointmentsContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.User.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

    }
}
