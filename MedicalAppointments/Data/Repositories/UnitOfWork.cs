using MedicalAppointments.Models;

namespace MedicalAppointments.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MedicalAppointmentsContext _medicalAppointmentsContext;

        private IRepository<Pacient> _userRepository;
       


        public UnitOfWork(MedicalAppointmentsContext medicalAppointmentsContext,
                            IRepository<Pacient> pacientRepository)
        {
            _medicalAppointmentsContext = medicalAppointmentsContext;
            _userRepository = pacientRepository;
        }

        public IRepository<Pacient> PacientRepository { get { return _userRepository; } }


        public void Save()
        {
            _medicalAppointmentsContext.SaveChanges();
        }
    }
}
