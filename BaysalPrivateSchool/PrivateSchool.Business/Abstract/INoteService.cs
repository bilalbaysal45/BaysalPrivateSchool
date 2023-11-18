using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NoteDtos;

namespace PrivateSchool.Business.Abstract
{
    public interface INoteService
    {
        ResponseDto<List<NoteDto>> GetAll();
        ResponseDto<NoteDto> GetById(int id);
        ResponseDto<NoteDto> Create(AddNoteDto newNoteDto);
        ResponseDto<NoteDto> Update(UpdateNoteDto updateNoteDto);
    }
}