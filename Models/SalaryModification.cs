using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace v3x.Models
{
    public class SalaryModification
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public double Bonus { get; set; }
        public double TotalRate { get; set; }
        public double AdvancePay { get; set; }
        public int EPFId { get; set; }
        public int SocsoId { get; set; }
        public int JobId { get; set; }

    }
}
