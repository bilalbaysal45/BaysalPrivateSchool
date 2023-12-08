using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NewsDtos;
using PrivateSchool.Shared.Dtos.NoteDtos;
using PrivateSchool.Shared.Dtos.StudentDtos;

namespace PrivateSchool.Business.mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, AddTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<News, AddNewsDto>().ReverseMap();
            CreateMap<News, UpdateNewsDto>().ReverseMap();

            CreateMap<SchoolInfo, SchoolInfoDto>().ReverseMap();
            CreateMap<StudentClub, StudentClubDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<Note,NoteDto>().ReverseMap();
            CreateMap<Note,AddNoteDto>().ReverseMap();
            CreateMap<Note,UpdateNoteDto>().ReverseMap();

            //CreateMap<StudentClub,StudentClubDto>().ReverseMap(); //Updated to Below
            CreateMap<StudentClub, StudentClubDto>()
                .ForMember(scdto => scdto.News, opt =>
                    opt.MapFrom(sc => sc.StudentClubsNews.Select(scn => scn.News)));
        }
    }
}