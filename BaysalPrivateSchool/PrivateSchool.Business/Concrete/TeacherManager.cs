using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NoteDtos;

namespace PrivateSchool.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherManager(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public ResponseDto<List<TeacherDto>> GetAll()
        {
            var response = new ResponseDto<List<TeacherDto>>();
            List<Teacher> teachers = _teacherRepository.GetAll();
            if(teachers.Count != 0)
            {
                var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers);
                response.Data = teacherDtos;
                response.Error = null;
            }
            else{
                response.Data = new List<TeacherDto>();
                response.Error = "Not Found";
            }
            return response;
        }
        public ResponseDto<TeacherDto> GetById(int id)
        {
            var response = new ResponseDto<TeacherDto>();
            var teacher = _teacherRepository.GetById(id);
            if(teacher != null)
            {
                response.Data = _mapper.Map<TeacherDto>(teacher);
                response.Error = null;
            }
            else
            {
                response.Data = null;
                response.Error = "Not Found";
            }
            return response;
        }

        public ResponseDto<TeacherDto> Create(AddTeacherDto addTeacherDto)
        {
            var addedTeacher = new Teacher();
            addedTeacher = _mapper.Map<Teacher>(addTeacherDto);
            addedTeacher.CreatedDate = DateTime.Now;
            addedTeacher.ModifiedDate = DateTime.Now;
            addedTeacher.IsDeleted = false;
            var responseTeacher = _teacherRepository.Create(addedTeacher);
            return new ResponseDto<TeacherDto>
            {
                Data = _mapper.Map<TeacherDto>(responseTeacher),
                Error = null
            };
        }

        public ResponseDto<TeacherDto> Update(UpdateTeacherDto updateTeacher)
        {
            if(updateTeacher != null)
            {
                var deparmentId = _teacherRepository.GetTeacherWithDepartmentId(updateTeacher.Id);
                var teacher = _mapper.Map<Teacher>(updateTeacher);
                teacher.DepartmentId =deparmentId;

                var response = _teacherRepository.Update(teacher);
                var teacherDto = _mapper.Map<TeacherDto>(response);
                return new ResponseDto<TeacherDto>{Data = teacherDto, Error = "Success"};
            }
            return null;
        }
        public void Delete(int teacherId)
        {
            var teacher = _teacherRepository.GetById(teacherId);
            _teacherRepository.Delete(teacher);
        }
        public ResponseDto<List<TeacherDto>> GetTeachersWithDepartment()
        {
            var response = new ResponseDto<List<TeacherDto>>();
            var teachers = _teacherRepository.GetTeachersWithDepartment();

            if(teachers.Count != 0)
            {
                var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers);
                response.Data = teacherDtos;
                response.Error = null;
            }
            else
            {
                response.Data = new List<TeacherDto>();
                response.Error = "Not Found";
            }
            return response;
        }
        public ResponseDto<bool> Login(LoginDto loginDto)
        {
            var login = new ResponseDto<bool>();
            var teachers = _teacherRepository.GetAll();
            foreach(var teacher in teachers)
            {
                if(teacher.Email == loginDto.Email && teacher.Password == loginDto.Password)
                {
                    login.Data = true;
                    login.Error = null;
                    return login;
                }
                else{
                    login.Data = false;
                    login.Error = "Wrong Credentials";
                }
            }
            return login;
        }
        public ResponseDto<TeacherWithClassesAndStudentsDto> GetTeacherWithClassesAndStudents(int id)
        {
            var response = _teacherRepository.GetTeacherWithClassesAndStudents(id);
            ResponseDto<TeacherWithClassesAndStudentsDto> x = new ResponseDto<TeacherWithClassesAndStudentsDto>();
            x.Data = new TeacherWithClassesAndStudentsDto();
            x.Data.Id = response.Id;
            x.Data.FirstName = response.FirstName;
            x.Data.LastName = response.LastName;
            x.Data.TeacherClasses = response.TeacherClasses;
            return x;
        }
        public ResponseDto<TeacherDto> GetTeacherWithLoginCredentials(LoginDto loginDto)
        {
            var teacher = _teacherRepository.GetTeacherWithLoginCredentials(loginDto.Email, loginDto.Password);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            if (teacherDto != null)
            {
                return new ResponseDto<TeacherDto> { Data = teacherDto, Error = null };
            }
            return new ResponseDto<TeacherDto> { Data = null, Error = "Not Found" };
        }
        public ResponseDto<StudentClubDto> GetStudentClubWithNewsByTeacherId(int teacherId)
        {
                var studentClub = _teacherRepository.GetStudentClubWithNewsByTeacherId(teacherId);
                if (studentClub != null)
                {
                    var studentClubDto = _mapper.Map<StudentClubDto>(studentClub);
                    return new ResponseDto<StudentClubDto> { Data = studentClubDto, Error = null };
                }
                else
                {
                    return new ResponseDto<StudentClubDto>{Data=null,Error="Not Found"};
                }
            
                return new ResponseDto<StudentClubDto>{Data=null,Error="Data Unreachable"};
            
        }
        
    }
}