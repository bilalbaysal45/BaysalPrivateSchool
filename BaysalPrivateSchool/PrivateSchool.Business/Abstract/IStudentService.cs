using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.StudentDtos;

namespace PrivateSchool.Business.Abstract
{
    public interface IStudentService
    {
        ResponseDto<List<StudentDto>> GetAll();
        ResponseDto<StudentDto> GetById(int id);
        ResponseDto<StudentDto> Create(AddStudentDto newStudentDto);
        ResponseDto<StudentDto> Update(UpdateStudentDto updateStudent);
        void Delete(int studentId);
    }
}