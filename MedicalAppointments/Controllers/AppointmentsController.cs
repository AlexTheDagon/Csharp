using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalAppointments.Models;
using System.Diagnostics;

namespace MedicalAppointments.Controllers
{
    public class AppointmentsController: Controller
    {
        private readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(ILogger<AppointmentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Appointment()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
