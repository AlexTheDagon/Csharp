using MedicalAppointments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Model.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<Pacient> PacientRepository { get; }
        public IRepository<Doctor> DoctorRepository { get; }

        public IRepository<Appointment> AppointmentRepository { get; }

        public void Save();
    }
}
