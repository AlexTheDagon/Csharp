using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointments.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public float Rating { get; set; }

    }
}
