using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v3x.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Status { get; set; }

        
    }
}
