using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.Abstract
{
    public interface IStudentClubService
    {
        ResponseDto<List<StudentClubDto>> GetStudentClubWithStudentsAndTeachers();
        ResponseDto<List<StudentClubDto>> GetStudentClubsWithNews();
    }
}