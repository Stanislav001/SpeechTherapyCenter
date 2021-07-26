using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapyCenter.Controllers
{
    public class ReservationController : Controller
    {
        public ReservationService serviceReservation { get; set; }

        public ReservationController(ReservationService reservation)
        {
            serviceReservation = reservation;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReservation([Bind("FirstName, LastName, Number, Email, City,KidName,KidYear,ServiceName,Gender,Date,Time")] ReservationViewModel reservation)
        {
            if (ModelState.IsValid)
            {
                await serviceReservation.AddReservation(reservation);
                return RedirectToAction(nameof(Index));
            }
            return Redirect("~/Home/Index");
        }
    }
}