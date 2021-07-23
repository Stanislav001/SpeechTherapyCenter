using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class PostViewModel
    {
        public string PostId { get; set; }
        [Display(Name = "Заглавие: ")]
        public string Title { get; set; }
        [Display(Name = "Съдържание: ")]
        public string Body { get; set; }
    }
}
