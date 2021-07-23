using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class ManagerViewModel
    {
        [Display(Name = "Име: ")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия: ")]
        public string LastName { get; set; }
    }
}
