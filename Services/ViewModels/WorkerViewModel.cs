using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Services.ViewModels
{
    public class WorkerViewModel
    {
        public string WorkerId { get; set; }
        [Display(Name = "Име: ")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия: ")]
        public string LastName { get; set; }
        [Display(Name = "Държава: ")]
        public string Country { get; set; }
        [Display(Name = "Възраст: ")]
        public int Year { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Стаж: ")]
        public int Internship { get; set; }
        [Display(Name = "Длъжност: ")]
        public string Position { get; set; }
        public string Info { get; set; }
    }
}
