﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Data.Static
{
    public class Helper
    {
        public const string adminEmail = "eMedical@admin.com";
        public const string adminPass = "admin";
        public static bool loginPacient = false;
        public static bool loginDoctor = false;
        public static bool loginAdmin = false;
        //0 -> nimeni nu e logat
        //1-> admin
        //2-> pacient
        //3-> doctor
        public static int role = 0;

        //public Helper()
        //{
        //    LoginAdmin = false;
        //    LoginPacient = false;
        //    LoginDoctor = false;
        //    Role = 0;
        //}
        //public bool LoginPacient { get; set; }
        //public bool LoginDoctor { get; set; }
        //public bool LoginAdmin { get; set; }
        //public int Role { get; set; }
     

    }
}
