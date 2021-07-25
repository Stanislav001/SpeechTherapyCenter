using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapyCenter.Controllers
{
    public class WorkerController : Controller
    {
        public WorkerService serviceWork { get; set; }

        public WorkerController(WorkerService service)
        {
            serviceWork = service;
        }

        // Shows all workers
        public async Task<IActionResult> Index()
        {
            return View(await serviceWork.GetAll());
        }

        public async Task<IActionResult> GetPost()
        {
            List<WorkerViewModel> result = await serviceWork.GetAll();
            return View("Index");
        }

        //Get worker by ID
        public async Task<IActionResult> GetWorkerById(string id)
        {
            WorkerViewModel result = await serviceWork.GetWorkerById(id);
            return View("_WorkerPartial", result);
        }
    }
}
