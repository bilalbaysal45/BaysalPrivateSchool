using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.Concrete
{
    public class StudentClubManager : IStudentClubService
    {
        private readonly IStudentClubRepository _studentClubRepository;
        private readonly IMapper _mapper;

        public StudentClubManager(IStudentClubRepository studentClubRepository, IMapper mapper)
        {
            _studentClubRepository = studentClubRepository;
            _mapper = mapper;
        }

        public ResponseDto<List<StudentClubDto>> GetStudentClubWithStudentsAndTeachers()
        {
            var response = new ResponseDto<List<StudentClubDto>>();
            var studentClubs = _studentClubRepository.GetStudentClubsWithStudentsAndTeachers();

            if(studentClubs.Count != 0)
            {
                var studentClubDtos = _mapper.Map<List<StudentClubDto>>(studentClubs);
                response.Data = studentClubDtos;
                response.Error = null;
            }
            else
            {
                response.Data = null;
                response.Error = "Not Found";
            }
            return response;
        }
    }
}