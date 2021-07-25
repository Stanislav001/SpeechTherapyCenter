using Date;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OfficeService
    {
        private readonly SpeechCenterDbContext context;
        public OfficeService(SpeechCenterDbContext service)
        {
            context = service;
        }

        // Show all posts
        public async Task<List<ServiceViewModel>> GetAll()
        {
            return await context.Services.Select(x => new ServiceViewModel()
            {
                ServiceId = x.Id,
                Title = x.Title,
                Body = x.Body
            }).ToListAsync();
        }


        // Get service by ID
        public async Task<ServiceViewModel> GetServiceById(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            else
            {
                var serviceDb = await context.Services.Where(x => x.Id == id).Select(x => new ServiceViewModel()
                {
                    ServiceId = x.Id,
                    Title= x.Title,
                    Body = x.Body,
                    FinishDate = x.FinishDate
                }).FirstOrDefaultAsync();
                return serviceDb;
            }
        }

    }
}
