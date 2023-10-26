using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrivateSchool.Data.Concrete.EfCore.Contexts
{
    public class PrivateSchoolDbContext : DbContext
    {
        public PrivateSchoolDbContext(DbContextOptions options) : base(options) 
        {

        }
    }
}