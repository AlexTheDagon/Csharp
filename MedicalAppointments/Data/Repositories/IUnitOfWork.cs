using MedicalAppointments.Models;

namespace MedicalAppointments.Data.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<Pacient> PacientRepository { get; }
       

        public void Save();
    }
}
