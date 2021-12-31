using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using BC = BCrypt.Net.BCrypt;
using MedicalAppointments.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MedicalAppointments.Data.Static;

namespace MedicalAppointments.Controllers
{
    public class LoginController : Controller
    {
        private readonly MedicalAppointmentsContext _context;


        public LoginController(MedicalAppointmentsContext context)
        {
            _context = context;

        }

        public IActionResult PageLogin() => View();


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
            if (email == Helper.adminEmail && password == Helper.adminPass)
            {
                Helper.loginAdmin = true;
                Helper.role = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (email.Contains("doctor.com"))
                {
                    var doctors = await _context.Doctor.ToListAsync();

                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                    {
                        var doc = doctors.FirstOrDefault(user => user.Mail == email);

                        if (doc == null)
                        {
                            return BadRequest("Invalid doctor!");

                        }
                        if (!VerifyPassword(password, doc.Password))
                        {
                            return BadRequest("Invalid credentials!");
                        }
                        Helper.role = 3;
                        Helper.loginDoctor = true;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return BadRequest("prostule!");
                }
                else
                {
                    var users = await _context.Pacient.ToListAsync();

                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                    {
                        var pacient = users.FirstOrDefault(user => user.Mail == email);

                        if (pacient == null)
                        {
                            return BadRequest("Invalid pacient!");

                        }
                        if (!VerifyPassword(password, pacient.Password))
                        {
                            return BadRequest("Invalid credentials!");
                        }
                        Helper.role = 2;
                        Helper.loginPacient = true;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return BadRequest("prostule!");
                }
            }
        }

        public void LogoutUser()
        {
            Helper.loginPacient = false;
            Helper.loginDoctor = false;
            Helper.loginAdmin = false;
            Helper.role = 0;
        }
    }
}
