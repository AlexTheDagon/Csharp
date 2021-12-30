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
        private readonly MedicalAppointmentsContext _context;


        //private SecurityService _securityService;


        public LoginController(MedicalAppointmentsContext context/*, SecurityService securityService*/)
        {
            _context = context;
           // _securityService = new SecurityService();

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

        }

    }
}
