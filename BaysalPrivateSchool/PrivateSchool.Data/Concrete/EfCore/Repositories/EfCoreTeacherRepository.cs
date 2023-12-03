using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Repositories
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(PrivateSchoolDbContext _context) : base(_context)
        {

        }
        PrivateSchoolDbContext Context
        {
            get{return _dbContext as PrivateSchoolDbContext;}
        }
        public List<Teacher> GetTeachersWithDepartment()
        {
            var teachers = Context
                            .Teachers
                            .Include(t => t.Department)
                            .ToList();
            return teachers;
        }
        public int? GetTeacherWithDepartmentId(int teacherId)
        {
            var teacher = Context.Teachers.AsNoTracking().SingleOrDefault(t=>t.Id==teacherId);
            
            
            
            return teacher.DepartmentId;
        }
        public Teacher GetTeacherWithClassesAndStudents(int id)
        {
            var teacher = Context.Teachers.Include(t => t.TeacherClasses).ThenInclude(tc => tc.SClass).ThenInclude(sc => sc.Students).ThenInclude(s=>s.Notes.Where(x=>x.TeacherId == id)).SingleOrDefault(t => t.Id == id);
            
            teacher.TeacherClasses.ForEach(t => t.Teacher = null);
            teacher.TeacherClasses.ForEach(tc => tc.SClass.Students.ForEach(s => s.Notes.ForEach(n=>n.Teacher = null)));
            return teacher;
        }
        public Teacher GetTeacherWithLoginCredentials(string email, string password)
        {
            var teacher = Context.Teachers.Where(t => t.Email == email && t.Password == password).SingleOrDefault();
            return teacher;
        }
        public StudentClub GetStudentClubWithNewsByTeacherId(int teacherId)
        {
            var studentClub = Context.StudentClubs.Include(sc=>sc.Teachers).Include(sc=>sc.Students).Include(sc=>sc.StudentClubsNews).ThenInclude(scn=>scn.News).SingleOrDefault(sc=>sc.Teachers.Any(t=>t.Id==teacherId));
            studentClub.Students.ForEach(s=>s.StudentClub=null);
            return studentClub;
        }

    }
}