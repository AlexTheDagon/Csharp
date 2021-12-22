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
                entity.Property(user => user.Email).HasColumnName("EMAIL");
                entity.Property(user => user.Password).HasColumnName("PASSWORD");
                entity.Property(user => user.Telephone).HasColumnName("TELEPHONE");
            });

            modelBuilder.Entity<Pacient>(entity =>
            {
                entity.ToTable("PACIENTS");
                entity.HasKey(pacient => pacient.Id);
                entity.Property(pacient => pacient.Id).HasColumnName("REMARKS");
                entity.Property(pacient => pacient.Age).HasColumnName("AGE");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("DOCTORS");
                entity.HasKey(doctor => doctor.Id);
                entity.Property(doctor => doctor.Id).HasColumnName("TYPE");
                entity.Property(doctor => doctor.Rating).HasColumnName("RATING");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENTS");
                entity.HasKey(appointment => appointment.Id);
                entity.Property(appointment => appointment.Id).HasColumnName("ID");
                entity.Property(appointment => appointment.Type).HasColumnName("TYPE");
                entity.Property(appointment => appointment.Date).HasColumnName("DATE");
                entity.Property(appointment => appointment.Pacient).HasColumnName("PACIENT");
                entity.Property(appointment => appointment.Doctor).HasColumnName("DOCTOR");
                entity.HasOne(appointment => appointment.Pacient).WithMany(pacient => pacient.Appointments);
                entity.HasOne(appointment => appointment.Doctor).WithMany(pacient => pacient.Appointments);


            });

        }

    }
}
