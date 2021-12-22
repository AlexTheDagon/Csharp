using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Models
{
    public class Doctor : Entity<int>
    {
        public string Type { get; set; }

        public int Rating { get; set; }
    }
}
