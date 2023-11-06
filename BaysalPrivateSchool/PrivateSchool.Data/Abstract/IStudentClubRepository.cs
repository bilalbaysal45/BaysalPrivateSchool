using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Abstract
{
    public interface IStudentClubRepository : IGenericRepository<StudentClub>
    {
        List<StudentClub> GetStudentClubsWithStudentsAndTeachers();
        List<StudentClub> GetStudentClubsWithNews();
    }
}