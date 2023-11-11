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
                    return login;
                }
            }
            return login;
        }
    }
}