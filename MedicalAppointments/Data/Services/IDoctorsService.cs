using MedicalAppointments.Data.Base;
using MedicalAppointments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PrimaPaginA.Data.Services
{
    public interface IDoctorsService : IEntityBaseRepository<Doctor>
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
        
       // Task AddNewDoctorAsync(NewMovieVM data);
       // Task UpdateDoctorAsync(NewMovieVM data);
    }
}
