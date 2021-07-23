using Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Post : Base
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Manager Manager { get; set; }
        public User User { get; set; }
        public Worker Worker { get; set; }
    }
}
