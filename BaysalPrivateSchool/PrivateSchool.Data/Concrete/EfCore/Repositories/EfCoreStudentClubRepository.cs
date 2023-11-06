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
    public class EfCoreStudentClubRepository : EfCoreGenericRepository<StudentClub>, IStudentClubRepository
    {
        public EfCoreStudentClubRepository(PrivateSchoolDbContext _context) : base(_context)
        {
        }

        PrivateSchoolDbContext Context
        {
            get{ return _dbContext as PrivateSchoolDbContext;}
        }

        public List<StudentClub> GetStudentClubsWithStudentsAndTeachers()
        {
            var studentClubs = Context
                                .StudentClubs
                                .Include(sc => sc.Students)
                                .ToList();
            studentClubs = Context
                                .StudentClubs
                                .Include(sc => sc.Teachers)
                                .ToList();
            return studentClubs;
        }
        public List<StudentClub> GetStudentClubsWithNews()
        {
            var studentClubsWithNews = Context
                                .StudentClubs
                                .Include(sc => sc.Students)
                                .Include(sc => sc.Teachers)
                                .Include(sc => sc.StudentClubsNews)
                                .ThenInclude(scn => scn.News)
                                .ToList();
            // studentClubsWithNews = Context
            //                     .StudentClubs
            //                     .Include(sc => sc.Teachers)
            //                     .Include(sc => sc.Students)
            //                     .ToList();
            return studentClubsWithNews;
        }
    }
}