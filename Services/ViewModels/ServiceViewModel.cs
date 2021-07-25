using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class ServiceViewModel
    {
        public string ServiceId { get; set; }
        [Display(Name = "Заглавие: ")]
        public string Title { get; set; }
        [Display(Name = "Описание: ")]
        public string Body { get; set; }
        [Display(Name = "Дата на провеждане: ")]
        public DateTime StartDate = DateTime.Now;
        public DateTime FinishDate { get; set; }
    }
}
