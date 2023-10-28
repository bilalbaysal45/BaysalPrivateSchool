using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Repositories
{
    public class EfCoreSchoolInfoRepository : EfCoreGenericRepository<SchoolInfo>, ISchoolInfoRepository
    {
        public EfCoreSchoolInfoRepository(PrivateSchoolDbContext _context) : base(_context)
        {
        }
        PrivateSchoolDbContext Context 
        {
            get
            {
                return _dbContext as PrivateSchoolDbContext;
            }
        }
    }
}