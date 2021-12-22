using MedicalAppointments.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace MedicalAppointments.Model.Contexts
{
    public class MedicalAppointmentsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Pacient> Pacients { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Doctor> Doctors { get; set; }

        public MedicalAppointmentsContext(DbContextOptions<MedicalAppointmentsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");
                entity.HasKey(user => user.Id);
                entity.Property(user => user.Id).HasColumnName("ID");
                entity.Property(user => user.Name).HasColumnName("NAME");
                entity.Property(user => user.Description).HasColumnName("DESCRIPTION");
                entity.Property(user => user.Email).HasColumnName("EMAIL");
                entity.Property(user => user.Password).HasColumnName("PASSWORD");

            });

        }

    }
}
