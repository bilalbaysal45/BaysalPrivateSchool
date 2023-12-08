using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Repositories
{
    public class EfCoreStudentClubsNewsRepository : EfCoreGenericRepository<StudentClubsNews>, IStudentClubsNewsRepository
    {
        public EfCoreStudentClubsNewsRepository(PrivateSchoolDbContext _context) : base(_context){}
        PrivateSchoolDbContext Context{get{return _dbContext as PrivateSchoolDbContext;}}
        
    }
}