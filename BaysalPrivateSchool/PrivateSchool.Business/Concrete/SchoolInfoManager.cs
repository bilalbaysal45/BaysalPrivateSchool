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
    public class SchoolInfoManager : ISchoolInfoService
    {
        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly IMapper _mapper;
        public SchoolInfoManager(ISchoolInfoRepository schoolInfoRepository,IMapper mapper)
        {
            _schoolInfoRepository = schoolInfoRepository;
            _mapper = mapper;
        }
        public ResponseDto<List<SchoolInfoDto>> GetAll()
        {
            var response = new ResponseDto<List<SchoolInfoDto>>();
            List<SchoolInfo> schoolInfos = _schoolInfoRepository.GetAll();
            if (schoolInfos.Count != 0)
            {
                var schoolInfoDtos = _mapper.Map<List<SchoolInfoDto>>(schoolInfos);
                response.Data = schoolInfoDtos;
                response.Error = null;
            }
            else
            {
                response.Data = new List<SchoolInfoDto>();
                response.Error = "Not Found";
            }
            return response;
        }
    }
}