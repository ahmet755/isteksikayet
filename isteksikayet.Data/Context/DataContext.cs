using isteksikayet.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Data.Context
{
    public class DataContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=USER;Database=DataDb;Integrated Security=True");
        }
    }
}
