using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        List<Teacher> GetTeachersWithDepartment();
        int? GetTeacherWithDepartmentId(int teacherId);
        Teacher GetTeacherWithClassesAndStudents(int id);
        Teacher GetTeacherWithLoginCredentials(string email, string password);


    }
}