using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Models
{
    public class Pacient : Entity<int>
    {
        public string Remarks { get; set; }

        public int Age { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
