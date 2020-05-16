using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v3x.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string Role { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        

    }
}
