using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Data.Static
{
    public class Helper
    {
        public static string adminEmail = "eMedical@admin.com";
        public static string adminPass = "admin";
        public static bool loginPacient = false;
        public static bool loginDoctor = false;
        public static bool loginAdmin = false;
        //0 -> nimeni nu e logat
        //1-> admin
        //2-> pacient
        //3-> doctor
        public static int role = 0; //nush exact daca avem nevoie de asta

    }
}
