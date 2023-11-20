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
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(PrivateSchoolDbContext _context) : base(_context)
        {

        }
        PrivateSchoolDbContext Context{get{ return _dbContext as PrivateSchoolDbContext;}}

        public Student GetStudentWithLoginCredentials(string email, string password)
        {
            var student = Context.Students.Where(t=> t.Email == email && t.Password == password).SingleOrDefault();
            return student;
        }
        public Student GetStudentWithStudentClub(int studentId)
        {
            var student = Context.Students.Include( s => s.StudentClub).FirstOrDefault(t => t.Id == studentId);
            return student;
        }
        public Student GetStudentWithNotes(int id)
        {
            var student = Context.Students.Where(s=>s.Id == id).Include(s => s.Notes).SingleOrDefault();
            student.Notes.ForEach(n =>n.Student = null);
            return student;
        }
        
    }
}