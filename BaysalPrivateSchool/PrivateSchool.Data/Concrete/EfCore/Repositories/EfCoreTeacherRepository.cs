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
            var teacher = Context.Teachers.Include(tc => tc.TeacherClasses).ThenInclude(sc => sc.SClass).ThenInclude(s => s.Students).SingleOrDefault(t => t.Id == id);
            teacher.TeacherClasses.ForEach(t => t.Teacher = null);
            return teacher;
        }
        public Teacher GetTeacherWithLoginCredentials(string email, string password)
        {
            var teacher = Context.Teachers.Where(t => t.Email == email && t.Password == password).SingleOrDefault();
            return teacher;
        }


    }
}