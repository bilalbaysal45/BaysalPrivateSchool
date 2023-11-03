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