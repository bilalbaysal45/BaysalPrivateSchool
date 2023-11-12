using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.Abstract
{
    public interface ITeacherService
    {
        ResponseDto<List<TeacherDto>> GetAll();
        ResponseDto<TeacherDto> GetById(int id);
        ResponseDto<TeacherDto> Create(AddTeacherDto newTeacherDto);
        ResponseDto<TeacherDto> Update(UpdateTeacherDto updateTeacher);
        void Delete(int teacherId);
        ResponseDto<List<TeacherDto>> GetTeachersWithDepartment();
        ResponseDto<bool> Login(LoginDto loginDto);
    }
}