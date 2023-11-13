using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.StudentDtos;

namespace PrivateSchool.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentManager(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public ResponseDto<StudentDto> Create(AddStudentDto newStudentDto)
        {
            var student = _mapper.Map<Student>(newStudentDto);
            if(student != null)
            {
                var response = _studentRepository.Create(student);
                return new ResponseDto<StudentDto>{Data=_mapper.Map<StudentDto>(response),Error=null};
            }
            else
            {
                return new ResponseDto<StudentDto>{Data=null,Error="Error"};
            }
        }

        public void Delete(int studentId)
        {
            var student = _studentRepository.GetById(studentId);
            if(student != null)
            {
                _studentRepository.Delete(student);
            }
        }

        public ResponseDto<List<StudentDto>> GetAll()
        {
            var students = _studentRepository.GetAll();
            if (students.Count != 0)
            {
                var studentsDto = _mapper.Map<List<StudentDto>>(students);
                return new ResponseDto<List<StudentDto>> { Data = studentsDto, Error = null };
            }
            else
            {
                return new ResponseDto<List<StudentDto>> { Data = null, Error = "Not Found" };
            }
        }

        public ResponseDto<StudentDto> GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if(student != null)
            {
                var studentDto = _mapper.Map<StudentDto>(student);
                return new ResponseDto<StudentDto>{Data = studentDto,Error=null};
            }
            else
            {
                return new ResponseDto<StudentDto>{Data=null,Error="Not Found"};
            }
        }

        public ResponseDto<StudentDto> Update(UpdateStudentDto updateStudent)
        {
            var student = _mapper.Map<Student>(updateStudent);
            if(student != null)
            {
                student.ModifiedDate = DateTime.Now;
                var response = _studentRepository.Update(student);
                return new ResponseDto<StudentDto>{Data=_mapper.Map<StudentDto>(response),Error=null};
            }
            else
            {
                return new ResponseDto<StudentDto>{Data=null,Error="Student Null"};
            }
        }
    }
}