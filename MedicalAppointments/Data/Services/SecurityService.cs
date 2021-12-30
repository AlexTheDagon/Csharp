using BC = BCrypt.Net.BCrypt;

namespace MedicalAppointments.Data.Services
{
    public class SecurityService : ISecurityService
    {
        public string HashPassword(string password)
        {
            return BC.HashPassword(password);
        }
        public bool VerifyPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
