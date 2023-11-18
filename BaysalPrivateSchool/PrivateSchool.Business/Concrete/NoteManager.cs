using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Entity.Concrete;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.NoteDtos;

namespace PrivateSchool.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteManager(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public ResponseDto<NoteDto> Create(AddNoteDto newNoteDto)
        {
            var note = _mapper.Map<Note>(newNoteDto);
            var response = _noteRepository.Create(note);
            if(response != null)
            {
                return new ResponseDto<NoteDto>{Data= _mapper.Map<NoteDto>(response),Error=null};
            }
            return new ResponseDto<NoteDto>{Data=null,Error="Not Created"};
        }

        public ResponseDto<List<NoteDto>> GetAll()
        {
            var noteDtos = new ResponseDto<List<NoteDto>>();
            var notes = _noteRepository.GetAll();
            if (notes.Count != 0)
            {
                noteDtos.Data = _mapper.Map<List<NoteDto>>(notes);
                noteDtos.Error = null;
                return noteDtos;
            }

            return new ResponseDto<List<NoteDto>> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<NoteDto> GetById(int id)
        {
            var noteDto = new ResponseDto<NoteDto>();
            var note = _noteRepository.GetById(id);
            if(note != null)
            {
                noteDto.Data = _mapper.Map<NoteDto>(note);
                noteDto.Error = null;
                return noteDto;
            }
            return new ResponseDto<NoteDto>{Data=null,Error="Not Found"};
        }

        public ResponseDto<NoteDto> Update(UpdateNoteDto updateNoteDto)
        {
            var note = _mapper.Map<Note>(updateNoteDto);
            var response = _noteRepository.Update(note);
            if(response != null)
            {
                return new ResponseDto<NoteDto>{Data = _mapper.Map<NoteDto>(response),Error=null};
            }
            return new ResponseDto<NoteDto>{Data=null,Error="Error"};
        }
    }
}