using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace v3x.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Status { get; set; }

        public double BasePay { get; set; }
        public string Position { get; set; }
        public int PeopleId { get; set; }

    }
}
