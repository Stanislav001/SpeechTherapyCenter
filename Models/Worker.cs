using Models.BaseModel;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Worker : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Salary { get; set; }
        public int Internship { get; set; }
        public string Position { get; set; }
        public string Info { get; set; }
        public ICollection<Manager> Managers { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
