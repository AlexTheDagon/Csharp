using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointments.Models
{
    public class Appointment
    {
        [Required]
        public int Id { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public int PacientID { get; set; }
        public Pacient Pacient { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Type { get; set; }
        public string Observations { get; set; }

    }
}