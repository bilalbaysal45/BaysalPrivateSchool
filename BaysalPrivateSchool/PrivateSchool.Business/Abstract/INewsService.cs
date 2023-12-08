using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NewsDtos;

namespace PrivateSchool.Business.Abstract
{
    public interface INewsService
    {
        ResponseDto<AddNewsDto> Create(AddNewsDto addNews);
        ResponseDto<NewsDto> GetById(int id);
        ResponseDto<UpdateNewsDto> Update(UpdateNewsDto updateNews);

    }
}