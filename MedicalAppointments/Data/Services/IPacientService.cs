using MedicalAppointments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Data.Services
{
    public interface IPacientService
    {
        public Pacient LoginUser(string email, string password);
       
    }
}
