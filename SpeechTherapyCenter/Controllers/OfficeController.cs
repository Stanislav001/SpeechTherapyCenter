using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapyCenter.Controllers
{
    public class OfficeController : Controller
    {
        public OfficeService serviceOffice { get; set; }

        public OfficeController(OfficeService service)
        {
            serviceOffice = service;
        }

        // Shows all posts
        public async Task<IActionResult> Index()
        {
            return View(await serviceOffice.GetAll());
        }

        public async Task<IActionResult> GetService()
        {
            List<ServiceViewModel> result = await serviceOffice.GetAll();
            return View("Index");
        }

        //Get service by ID
        public async Task<IActionResult> GetServiceById(string id)
        {
            ServiceViewModel result = await serviceOffice.GetServiceById(id);
            return View("_WorkerPartial", result);
        }
    }
}
