using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public ResponseDto<List<DepartmentDto>> GetAll()
        {
            var response = new ResponseDto<List<DepartmentDto>>();
            var departments = _departmentRepository.GetAll();
            if(departments.Count != 0)
            {
                response.Data = _mapper.Map<List<DepartmentDto>>(departments);
                response.Error = null;
            }
            else
            {
                response.Data = new List<DepartmentDto>();
                response.Error = "Not Found";
            }
            return response;
        }
    }
}