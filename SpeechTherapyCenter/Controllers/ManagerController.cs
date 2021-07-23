using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapyCenter.Controllers
{
    public class ManagerController : Controller
    {

        public ManagerService serviceManager { get; set; }

        public ManagerController(ManagerService service)
        {
            serviceManager = service;
        }


        // Shows all assigned employees
        public async Task<IActionResult> Index()
        {
            return View(await serviceManager.GetAll());
        }

        public async Task<IActionResult> GetWorker()
        {
            List<WorkerViewModel> result = await serviceManager.GetAll();
            return View("Index");
        }

        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorker([Bind("FirstName, LastName, Email,Password,UserName,Country, Year, Salary,Internship,Position")] WorkerViewModel worker)
        {
            if (ModelState.IsValid)
            {
                await serviceManager.AddWorker(worker);
                return RedirectToAction(nameof(Index));
            }
            return Redirect("~/Home/Index");
        }

        // Deleting an worker
        public async Task<IActionResult> DeleteWorker(string? id)
        {
            await serviceManager.DeleteWorker(id);
            return Redirect("~/Home/Index");
        }

        // Add new role
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(CreateRoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                await serviceManager.AddRole(roleModel);
                return RedirectToAction(nameof(Index));
            }
            return Redirect("~/Home/Index");
        }

        // Add a new service
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService([Bind("Title, Body,Date")] ServiceViewModel service)
        {
            if (ModelState.IsValid)
            {
                await serviceManager.AddService(service);
                return RedirectToAction(nameof(Index));
            }
            return Redirect("~/Home/Index");
        }
    }
}
