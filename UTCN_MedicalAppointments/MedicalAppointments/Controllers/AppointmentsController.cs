﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAppointments.Data;
using MedicalAppointments.Models;
using MedicalAppointments.Data.Static;

namespace MedicalAppointments.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly MedicalAppointmentsContext _context;

        public AppointmentsController(MedicalAppointmentsContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var medicalAppointmentsContext = _context.Appointment.Include(a => a.Doctor).Include(a => a.Pacient);
            return View(await medicalAppointmentsContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Pacient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor.ToList().AsEnumerable(), "Id", "Name", "----select----");
            ViewData["PacientID"] = new SelectList(_context.Pacient.ToList().AsEnumerable(), "Id", "Name", "----select----");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorID,PacientID,DateAndTime,Type,Observations")] Appointment appointment)
        {
            string selectedValue = Request.Form["DoctorId"].ToString();
            var doctor = _context.Doctor.FirstOrDefault(d => Equals(d.Id.ToString(), selectedValue));
            appointment.DoctorID = doctor.Id;
            var app = _context.Appointment.ToList(); //take all appointments
            var a = app.Where(ap => (ap.DoctorID == doctor.Id)).ToList(); //filter appointemnt for current doctor
            var exists = a.Where(currentIndex => currentIndex.DateAndTime == appointment.DateAndTime).ToList();
            if (exists.Count > 0)
            {
               return BadRequest("Doctor already has an appointment at that time.Try again!");
            }
            else
            {
                if (Helper.role == 2)
                {
                    appointment.PacientID = Helper.idPacient;
                }

                if (ModelState.IsValid)
                {
                    _context.Add(appointment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                ViewData["DoctorID"] = new SelectList(_context.Doctor.ToList().AsEnumerable(), "Id", "Name", "----select----");
                ViewData["PacientID"] = new SelectList(_context.Pacient.ToList().AsEnumerable(), "Id", "Name", "----select----");
                return View(appointment);
            }
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            //var query = _context.Doctor.ToList();
            //ViewBag.list = new SelectList(query.AsEnumerable(), "Id", "Name", "----select----");
            ViewData["DoctorID"] = new SelectList(_context.Doctor.ToList().AsEnumerable(), "Id", "Name", "----select----");
            ViewData["PacientID"] = new SelectList(_context.Pacient.ToList().AsEnumerable(), "Id", "Name", "----select----");
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorID,PacientID,DateAndTime,Type,Observations")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            string selectedValue = Request.Form["DoctorId"].ToString();
            var doctor = _context.Doctor.FirstOrDefault(d => Equals(d.Id.ToString(), selectedValue));
            appointment.DoctorID = doctor.Id;
            var app = _context.Appointment.ToList(); //take all appointments
            var a = app.Where(ap => (ap.DoctorID == doctor.Id)).ToList(); //filter appointemnt for current doctor
            var exists = a.Where(currentIndex => currentIndex.DateAndTime == appointment.DateAndTime).ToList();
            if (exists.Count > 0)
            {
                return BadRequest("Doctor already has an appointment at that time.Try again!");
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor.ToList().AsEnumerable(), "Id", "Name", "----select----");
            ViewData["PacientID"] = new SelectList(_context.Pacient.ToList().AsEnumerable(), "Id", "Name", "----select----");
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Pacient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AppointmentsDoctor(int id)
        {
            var medicalAppointmentsContext = _context.Appointment.Include(a => a.Doctor).Where(a => a.DoctorID == id).Include(a => a.Pacient);
            if (medicalAppointmentsContext != null)
            {
                return View(await medicalAppointmentsContext.ToListAsync());
            }
            else
            {
                return BadRequest("No appointments available");
            }
        }
        public IActionResult GoBack()
        {
            return RedirectToAction("DoctorPage", "Login");
        }

        public async Task<IActionResult> AppointmentsPacient(int id)
        {
            var medicalAppointmentsContext = _context.Appointment.Include(a => a.Doctor).Where(a => a.PacientID == id).Include(a => a.Pacient);
            if (medicalAppointmentsContext != null)
            {
                return View(await medicalAppointmentsContext.ToListAsync());
            }
            else
            {
                return BadRequest("No appointments available for now");
            }
        }
        public IActionResult GoBackPacient()
        {
            return RedirectToAction("PacientPage", "Login");
        }
    }
}
