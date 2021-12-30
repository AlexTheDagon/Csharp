using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalAppointments.Models;

namespace MedicalAppointments.Data
{
    public class MedicalAppointmentsContext : DbContext
    {
        public MedicalAppointmentsContext (DbContextOptions<MedicalAppointmentsContext> options)
            : base(options)
        {
        }


        public DbSet<MedicalAppointments.Models.Pacient> Pacient { get; set; }

        public DbSet<MedicalAppointments.Models.Doctor> Doctor { get; set; }

        public DbSet<MedicalAppointments.Models.Appointment> Appointment { get; set; }
    }
}
