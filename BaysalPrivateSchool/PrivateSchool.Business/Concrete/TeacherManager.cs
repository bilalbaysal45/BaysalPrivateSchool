using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}