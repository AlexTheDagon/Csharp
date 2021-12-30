using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointments.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MedicalAppointments.Data;
using Microsoft.EntityFrameworkCore;
using MedicalAppointments.Data.ViewModels;
using MedicalAppointments.Data.Services;
using System;
using System.Linq;

using BC = BCrypt.Net.BCrypt;

namespace MedicalAppointments.Controllers
{
    public class LoginController: Controller
    {
        /*private readonly MedicalAppointmentsContext _context;



        public LoginController(MedicalAppointmentsContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Pacients()
        {
            var users = await _context.Pacient.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View();


        public string HashPassword(string password)
        {
            return BC.HashPassword(password);
        }
        public bool VerifyPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
        
            var users = await _context.Pacient.ToListAsync();

            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                 var pacient = users.FirstOrDefault(user => user.Mail == email);

                if (pacient == null)
                {
                    return BadRequest("Invalid pacient!");
                    
                }
                if (!VerifyPassword(password, pacient.Password))
                {
                    return BadRequest("Invalid credentials!");
                };
                //return Ok(pacient);
                return RedirectToAction("Index", "Home");
            }
            else
                return BadRequest("prostule!");

        }*/




        private readonly UserManager<Pacient> _userManager;
        private readonly SignInManager<Pacient> _signInManager;
        private readonly MedicalAppointmentsContext _context;

        public LoginController(UserManager<Pacient> userManager, SignInManager<Pacient> signInManager, MedicalAppointmentsContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IActionResult> Pacients()
        {
            var users = await _context.Pacient.ToListAsync();
            return View(users);
        }

        public IActionResult PageLogin() => View();

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
                        return RedirectToAction("Index", "Movies");
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
