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

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        [Required]
        public int PacientID { get; set; }

        [Required]
        public Pacient Pacient { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public String Type { get; set; }

        [Required]
        public string Observations { get; set; }

    }
}