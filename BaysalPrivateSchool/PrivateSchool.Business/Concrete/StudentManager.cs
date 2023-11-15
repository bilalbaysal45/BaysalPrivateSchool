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
            if (student != null)
            {
                var response = _studentRepository.Create(student);
                return new ResponseDto<StudentDto> { Data = _mapper.Map<StudentDto>(response), Error = null };
            }
            else
            {
                return new ResponseDto<StudentDto> { Data = null, Error = "Error" };
            }
        }

        public void Delete(int studentId)
        {
            var student = _studentRepository.GetById(studentId);
            if (student != null)
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
            if (student != null)
            {
                var studentDto = _mapper.Map<StudentDto>(student);
                return new ResponseDto<StudentDto> { Data = studentDto, Error = null };
            }
            else
            {
                return new ResponseDto<StudentDto> { Data = null, Error = "Not Found" };
            }
        }

        public ResponseDto<StudentDto> Update(UpdateStudentDto updateStudent)
        {
            var student = _mapper.Map<Student>(updateStudent);
            if (student != null)
            {
                student.ModifiedDate = DateTime.Now;
                var response = _studentRepository.Update(student);
                return new ResponseDto<StudentDto> { Data = _mapper.Map<StudentDto>(response), Error = null };
            }
            else
            {
                return new ResponseDto<StudentDto> { Data = null, Error = "Student Null" };
            }
        }
        public ResponseDto<bool> Login(LoginDto loginDto)
        {
            var login = new ResponseDto<bool>();
            var students = _studentRepository.GetAll();
            foreach (var student in students)
            {
                if (student.Email == loginDto.Email && student.Password == loginDto.Password)
                {
                    login.Data = true;
                    login.Error = null;
                    return login;
                }
                else
                {
                    login.Data = false;
                    login.Error = "Wrong Credentials";
                    return login;
                }
            }
            return login;
        }
        public ResponseDto<StudentDto> GetStudentWithLoginCredentials(LoginDto loginDto)
        {
            var student = _studentRepository.GetStudentWithLoginCredentials(loginDto.Email, loginDto.Password);
            var studentDto = _mapper.Map<StudentDto>(student);
            if(studentDto !=null)
            {
                return new ResponseDto<StudentDto>{Data = studentDto,Error=null};
            }
            return new ResponseDto<StudentDto>{Data=null,Error="Not Found"};
        }
        public ResponseDto<bool> ChangeStudentClub(ChangeStudentClubDto changeStudentClub)
        {
            var student = _studentRepository.GetById(changeStudentClub.Id);
            student.StudentClubId = changeStudentClub.StudentClubId;
            var response = _studentRepository.Update(student);
            if(response.StudentClubId == changeStudentClub.StudentClubId)
            {
                return new ResponseDto<bool>{Data = true, Error=null};
            }
            return new ResponseDto<bool> { Data = false, Error = "Error" };
        }
    }
}