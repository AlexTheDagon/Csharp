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

        public DbSet<MedicalAppointments.Models.User> User { get; set; }

        public DbSet<MedicalAppointments.Models.Pacient> Pacient { get; set; }
    }
}
