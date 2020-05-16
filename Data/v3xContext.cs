using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using v3x.Models;

namespace v3x.Data
{
    public class v3xContext : DbContext
    {
        public v3xContext(DbContextOptions<v3xContext> options)
            : base(options)
        {
        }

        public DbSet<People> People { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<EPF> EPF { get; set; }
        public DbSet<Job> Job { get; set; }        
        public DbSet<SalaryModification> SalaryModification { get; set; }
        public DbSet<Socso> Socso { get; set; }
        public DbSet<PaySlip> PaySlip { get; set; }
    }
}
