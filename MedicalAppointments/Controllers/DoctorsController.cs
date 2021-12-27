using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalAppointments.Models;
using System.Diagnostics;
using PrimaPaginA.Data.Services;

namespace MedicalAppointments.Controllers
{
   
    public class DoctorsController : Controller
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IDoctorsService _service;


        public DoctorsController(ILogger<AppointmentsController> logger, IDoctorsService service)
        {
            _logger = logger;
            _service = service;
        }
        [AllowAnonymous]
        public IActionResult Doctor()
        {
            // var allMovies = await _service.GetAllAsync(n => n.Cinema);
            // return View(allMovies);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
   
    