using Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Manager : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}
