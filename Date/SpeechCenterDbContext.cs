using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Date
{
    public class SpeechCenterDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public SpeechCenterDbContext()
        {
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed
            var firstWorker = new Worker()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                FirstName = "Ивана",
                LastName = "Петрова",
                Country = "България",
                Year = 35,
                Salary = 2000,
                Internship = 8,
                Position = "Специален психолог"
            };

            var secondWorker = new Worker()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                FirstName = "Миглена",
                LastName = "Ангелова",
                Country = "България",
                Year = 30,
                Salary = 950,
                Internship = 6,
                Position = "Логопед"
            };

            var thirdWorker = new Worker()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                FirstName = "Яница",
                LastName = "Георгиева",
                Country = "България",
                Year = 25,
                Salary = 1000,
                Internship = 5,
                Position = "Рехабилитатор и психолог"
            };

            var manager = new Manager()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                FirstName = "Невяна",
                LastName = "Славова"
            };

            var post1 = new Post()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Добре дошли!",
                Body = "Надяваме се да споделяте мненията си за сайта ни!"
            };

            var AdminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin" };
            var UserRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User" };

            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<IdentityRole>().HasData(AdminRole, UserRole);
            modelBuilder.Entity<Worker>().HasData(firstWorker, secondWorker, thirdWorker);
            modelBuilder.Entity<Manager>().HasData(manager);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4EJHC35;Database=SpeechCenter;Trusted_Connection=True");
        }
    }
}
