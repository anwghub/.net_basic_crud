using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set;} //constructor
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
            
        }
    }
}