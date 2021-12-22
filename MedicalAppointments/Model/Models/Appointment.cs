using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Models
{
    public class Appointment : Entity<int>
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public Pacient Pacient { get; set; }

        public Doctor Doctor { get; set; }



        ///?
        public String Files { get; set; }

    }
}
