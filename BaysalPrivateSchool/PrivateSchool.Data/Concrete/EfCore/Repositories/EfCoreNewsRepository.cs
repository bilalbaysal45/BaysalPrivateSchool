using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Repositories
{
    public class EfCoreNewsRepository : EfCoreGenericRepository<News>, INewsRepository
    {
        public EfCoreNewsRepository(PrivateSchoolDbContext _context) : base(_context)
        {
        }
        PrivateSchoolDbContext Context
        { get { return _dbContext as PrivateSchoolDbContext; } }

        public StudentClub GetStudentClubByNewsId(int id)
        {

            var studentClub = Context
                                .StudentClubs
                                .Include(x=>x.Teachers)
                                .Include(x=>x.Students)
                                .Include(x => x.StudentClubsNews)
                                .ThenInclude(x => x.News)
                                .ToList().Find(x=>x.StudentClubsNews.Any(x=>x.News.Id==id));

            // var studentClub = studentClubList.Find(x=>x.StudentClubsNews.Any(x=>x.News.Id ==id));



            // studentClub = Context.StudentClubs.Include(x=>x.Students).FirstOrDefault();
            // studentClub = Context.StudentClubs.Include(x => x.Teachers).FirstOrDefault();

            studentClub.StudentClubsNews = null; // null vermezsem Club'a ait News'ları Tekrar Getiriyor 
            return studentClub;
        }
    }
}