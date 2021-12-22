using MedicalAppointments.Model.Contexts;
using MedicalAppointments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Model.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MedicalAppointmentsContext _medicalAppointmentsContext;

        public IRepository<User> _userRepository;

        public IRepository<Pacient> _pacientRepository;

        public IRepository<Doctor> _doctorRepository;

        public IRepository<Appointment> _appointmentRepository;


        public UnitOfWork(MedicalAppointmentsContext medicalAppointmentsContext,
            
            IRepository<User> userRepository,
            IRepository<Pacient> pacientRepository,
            IRepository<Doctor> doctorRepository,
            IRepository<Appointment> appointmentRepository)
        {
            _medicalAppointmentsContext = medicalAppointmentsContext;
            _userRepository = userRepository;
            _pacientRepository = pacientRepository;
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IRepository<User> UserRepository { get { return _userRepository; } }
        public IRepository<Pacient> PacientRepository { get { return _pacientRepository; } }
        public IRepository<Doctor> DoctorRepository { get { return _doctorRepository; } }
        public IRepository<Appointment> AppointmentRepository { get { return _appointmentRepository; } }

        public void Save()
        {
            _medicalAppointmentsContext.SaveChanges();
        }
    }
}
