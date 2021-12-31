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
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Observation { get; set; }


    }
}
