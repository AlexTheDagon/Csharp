using MedicalAppointments.Models;
using MedicalAppointments.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointments.Data.Services
{
    public class PacientService : IPacientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityService _securityService;
        private readonly MedicalAppointmentsContext _context;

        public PacientService(IUnitOfWork unitOfWork, ISecurityService serviceService, MedicalAppointmentsContext context)
        {
            _unitOfWork = unitOfWork;
            _securityService = serviceService;
            _context = context;
        }

        public Pacient LoginUser(string email, string password)
        {
           /* var users = _context.Pacient.ToListAsync();

            var user =  users.Where(user => user.Mail == email).ToList();

           /* if (user == null)
            {
                return null;
            }
            if (!_securityService.VerifyPassword(password, user.Password))
            {
                return null;
            };*/
            return null;
        }

      
    }
}
