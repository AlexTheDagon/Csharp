namespace MedicalAppointments.Data.Services
{
    public interface ISecurityService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string passwordHash);
    }
}
