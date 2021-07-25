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

            var firstService = new Service()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Логопедична терапия",
                Body = "Спечифична и индивидуална терапия, целяща преодоляването на различните говорни и езикови проблеми.",
               
            };

            var secondService = new Service()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Групова терапия",
                Body = "Целите са съобразени с групата. Извършват се различен вид занимания - игрови, ролеви, творчески с цел адаптация, социални и личностни умения.",

            };

            var threeService = new Service()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Психотерапия за деца",
                Body = "Целите са да поставят ясни граници и правила, да развива паметта, да помага за преодоляване на емоционални трудности и други подобни проблеми.",

            };

            var fourService = new Service()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Диагностициране",
                Body = "В нашия логопедичен център предлагаме изследване на говорния и комуникативния статус на детето и определяме нарушението и прецизно създаваме план за коригиране."
            };




            var AdminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin" };
            var UserRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User" };

            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<IdentityRole>().HasData(AdminRole, UserRole);
            modelBuilder.Entity<Worker>().HasData(firstWorker, secondWorker, thirdWorker);
            modelBuilder.Entity<Manager>().HasData(manager);
            modelBuilder.Entity<Service>().HasData(firstService, secondService, threeService, fourService);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4EJHC35;Database=SpeechCenter;Trusted_Connection=True");
        }
    }
}
