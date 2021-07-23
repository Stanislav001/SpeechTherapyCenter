using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.ViewModels
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Име: ")]
        public string UserName { get; set; }
        [Display(Name = "Държава: ")]
        public string Country { get; set; }
        public string Password { get; set; }
    }
}
