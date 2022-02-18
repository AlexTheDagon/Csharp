using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MedicalAppointments.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email adress.")]
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        [RegularExpression("[0-9]{10}", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Observation { get; set; }
    }
}
