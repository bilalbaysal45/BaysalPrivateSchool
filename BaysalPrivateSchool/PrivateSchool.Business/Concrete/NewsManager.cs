using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Repositories;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.Business.Concrete
{
    public class NewsManager : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsManager(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public ResponseDto<NewsDto> GetById(int id)
        {
            var news = _newsRepository.GetById(id);
            
            if(news != null)
            {
                var newsDto = new ResponseDto<NewsDto>();
                newsDto.Data = _mapper.Map<NewsDto>(news);
                newsDto.Data.StudentClub = GetStudentClubByNewsId(id);
                newsDto.Error = null;
                return newsDto;
            }
            else
            {
                return new ResponseDto<NewsDto>{
                    Data = null,
                    Error = "Not Found"
                };
            }
        }
        public StudentClubDto GetStudentClubByNewsId(int id)
        {
            var studentClub = _newsRepository.GetStudentClubByNewsId(id);
            var studentClubDto = _mapper.Map<StudentClubDto>(studentClub);
            return studentClubDto;
        }

    }
}