using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Abstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetStudentWithLoginCredentials(string email, string password);
        Student GetStudentWithStudentClub(int id);
        Student GetStudentWithNotes(int id);
    }
}