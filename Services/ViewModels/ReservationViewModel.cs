using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class ReservationViewModel
    {
        public string ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string ServiceName { get; set; }
        public string KidName { get; set; }
        public string KidYear { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
