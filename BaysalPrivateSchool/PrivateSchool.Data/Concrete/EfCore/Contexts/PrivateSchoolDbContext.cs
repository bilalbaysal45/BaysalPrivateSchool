using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Contexts
{
    public class PrivateSchoolDbContext : DbContext
    {
        public PrivateSchoolDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}