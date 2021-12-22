namespace MedicalAppointments.Models
{
    public class User : Entity<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Telephone { get; set; }
    }

 
}
