using System;
using System.Collections.Generic;
using System.IO.Compression;
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
            CreateMap<Teacher, AddTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();

            CreateMap<SchoolInfo, SchoolInfoDto>().ReverseMap();
            CreateMap<News,NewsDto>();
            CreateMap<StudentClub, StudentClubDto>().ReverseMap();
            CreateMap<Department,DepartmentDto>().ReverseMap();

            //CreateMap<StudentClub,StudentClubDto>().ReverseMap(); //Updated to Below
            CreateMap<StudentClub, StudentClubDto>()
                .ForMember(scdto => scdto.News, opt =>
                    opt.MapFrom(sc => sc.StudentClubsNews.Select(scn => scn.News)));
        }
    }
}