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
        ResponseDto<TeacherDto> Create(AddTeacherDto newTeacherDto);
        ResponseDto<List<TeacherDto>> GetTeachersWithDepartment();
        ResponseDto<bool> Login(LoginDto loginDto);
    }
}