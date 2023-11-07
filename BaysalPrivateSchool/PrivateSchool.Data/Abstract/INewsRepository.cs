using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Abstract
{
    public interface INewsRepository : IGenericRepository<News>
    {
        StudentClub GetStudentClubByNewsId(int id);
    }
}