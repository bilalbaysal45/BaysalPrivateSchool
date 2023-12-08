using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Data.Concrete.EfCore.Repositories;
using PrivateSchool.Data.Migrations;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NewsDtos;

namespace PrivateSchool.Business.Concrete
{
    public class NewsManager : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly IStudentClubsNewsRepository _studentClubsNewsRepository;

        public NewsManager(INewsRepository newsRepository, IMapper mapper,IStudentClubsNewsRepository studentClubsNewsRepository)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _studentClubsNewsRepository = studentClubsNewsRepository;
        }
        public ResponseDto<AddNewsDto> Create(AddNewsDto addNews)
        {
            try
            {
                if(addNews != null)
                {
                    var studentClubNews = new StudentClubsNews();
                    studentClubNews.StudentClubId = addNews.StudentClubId;
                    var news = _mapper.Map<News>(addNews);
                    var response = _newsRepository.Create(news);
                    studentClubNews.NewsId = response.Id;
                    _studentClubsNewsRepository.Create(studentClubNews);
                    return new ResponseDto<AddNewsDto>{Data = addNews,Error=null};
                }
                else
                {
                    return new ResponseDto<AddNewsDto>{Data=null,Error="Data's null"};
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<AddNewsDto>{Data=null,Error="Data couldn't Created."};
            }
        }
        public ResponseDto<UpdateNewsDto> Update(UpdateNewsDto updateNews)
        {
            try
            {
                if (updateNews != null)
                {
                    var news = _mapper.Map<News>(updateNews);
                    news.ModifiedDate = DateTime.Now;
                    var response = _newsRepository.Update(news);
                    return new ResponseDto<UpdateNewsDto> { Data = _mapper.Map<UpdateNewsDto>(response), Error = null };
                }
                else
                {
                    return new ResponseDto<UpdateNewsDto> { Data = null, Error = "Data's null" };
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<UpdateNewsDto> { Data = null, Error = "Data couldn't Created." };
            }
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