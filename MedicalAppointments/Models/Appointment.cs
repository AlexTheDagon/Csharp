using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointments.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public User User { get; set; }
        public DateTime DateAndTime { get; set; }
        public String Type { get; set; }
        public string Observations { get; set; }

    }
}