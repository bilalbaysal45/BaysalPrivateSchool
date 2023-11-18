using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Data.Concrete.EfCore.Configs;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Contexts
{
    //Database
    public class PrivateSchoolDbContext : DbContext
    {
        public PrivateSchoolDbContext(DbContextOptions options) : base(options)
        {

        }
        //Tablolar
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<SchoolInfo> SchoolInfos { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentClub> StudentClubs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<StudentClubsNews> StudentClubsNews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentClubsNewsConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}