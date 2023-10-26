using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Teacher,TeacherDto>().ReverseMap();
        }
    }
}