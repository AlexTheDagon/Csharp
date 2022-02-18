using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAppointments.Data;
using MedicalAppointments.Models;

using BC = BCrypt.Net.BCrypt;
namespace MedicalAppointments.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly MedicalAppointmentsContext _context;

        public DoctorsController(MedicalAppointmentsContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctor.ToListAsync());
        }
        public async Task<IActionResult> Doctors()
        {
            return View(await _context.Doctor.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mail,Password,Name,Phone,Age,Type,Rating")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Password = BC.HashPassword(doctor.Password);
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mail,Password,Name,Phone,Age,Type,Rating")] Doctor doctor)
        {

            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    doctor.Password = BC.HashPassword(doctor.Password);
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Filter(string searchString)
        {
            
            var allDoctors = await _context.Doctor.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                try
                {
                    var filteredResult = allDoctors.Where(n => (n.Name.ToLower().Contains(searchString.ToLower())) ||
                                                                     (n.Rating >= Convert.ToDouble(searchString)) ||
                                                                     string.Equals(n.Type.ToLower(), searchString.ToLower(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                    return View("Doctors", filteredResult);
                }
                catch (FormatException)
                {

                    var filteredResult = allDoctors.Where(n => (n.Name.ToLower().Contains(searchString.ToLower())) ||
                                                                     string.Equals(n.Type.ToLower(), searchString.ToLower(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                    return View("Doctors", filteredResult);

                }
            }

            return View("Doctors", allDoctors);
        }
        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
