using Date;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WorkerService
    {
        private readonly SpeechCenterDbContext context;
        public WorkerService(SpeechCenterDbContext worker)
        {
            context = worker;
        }

        // Show all worker 
        public async Task<List<WorkerViewModel>> GetAll()
        {
            return await context.Workers.Select(x => new WorkerViewModel()
            {
                WorkerId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Country = x.Country,
                Internship = x.Internship,
                Position = x.Position,
                Salary = x.Salary,
                Year = x.Year,
                Info = x.Info
            }).ToListAsync();
        }

        // Get worker by ID
        public async Task<WorkerViewModel> GetWorkerById(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            else
            {
                var workerDb = await context.Workers.Where(x => x.Id == id).Select(x => new WorkerViewModel()
                {
                    WorkerId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    Internship = x.Internship,
                    Position = x.Position,
                    Salary = x.Salary,
                    Year = x.Year,
                    Info = x.Info
                }).FirstOrDefaultAsync();
                return workerDb;
            }
        }
    }
}
