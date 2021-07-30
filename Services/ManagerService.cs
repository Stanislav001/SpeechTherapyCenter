using Date;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ManagerService
    {
        private readonly SpeechCenterDbContext context;
        public ManagerService(SpeechCenterDbContext manager)
        {
            context = manager;
        }

        // Show all employees
        public async Task<List<WorkerViewModel>> GetAll()
        {
            return await context.Workers.Select(x => new WorkerViewModel()
            {
                WorkerId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Country = x.Country,
                Year = x.Year,
                Internship = x.Internship,
                Position = x.Position,
                Salary = x.Salary,
                Info = x.Info
            }).ToListAsync();
        }

        // Adding a new employee
        public async Task AddWorker(WorkerViewModel worker)
        {
            var workerDb = new Worker();

            workerDb.Id = Guid.NewGuid().ToString();
            workerDb.FirstName = worker.FirstName;
            workerDb.LastName = worker.LastName;
            workerDb.Position = worker.Position;
            workerDb.Salary = worker.Salary;
            workerDb.Year = worker.Year;
            workerDb.Info = worker.Info;

            if (worker.FirstName != null)
            {
                context.Add(workerDb);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Eror!");
            }
        }

        // Delete an employee
        public async Task DeleteWorker(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var workerDb = context.Workers.FirstOrDefault(x => x.Id == id);
                context.Workers.Remove(workerDb);
                await context.SaveChangesAsync();
            }
        }

        // Add a  new role
        public async Task AddRole(CreateRoleViewModel roleModel)
        {
            var roleDb = new IdentityRole();

            roleDb.Id = Guid.NewGuid().ToString();
            roleDb.Name = roleModel.RoleName;

            if (roleModel.RoleName != null)
            {
                context.Add(roleDb);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Грешка!");
            }
        }


        // Add services
        public async Task AddService(ServiceViewModel service)
        {
            var serviceDb = new Service();

            service.ServiceId = Guid.NewGuid().ToString();
            serviceDb.Title = service.Title;
            serviceDb.Body = service.Body;

            if (service.Title != null)
            {
                context.Add(serviceDb);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Eror!");
            }
        }
    }
}