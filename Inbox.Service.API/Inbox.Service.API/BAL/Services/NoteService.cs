using Inbox.Service.API.DAL.Interfaces;
using Inbox.Service.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbox.Service.API.BAL.Services
{
    public class NoteService
    {
        private readonly INoteRepository<Note> _note;

        public NoteService(INoteRepository<Note> note)
        {
            _note = note;
        }

        //GET All Note Details   
        public IEnumerable<Note> GetAllNotes()
        {
            try
            {
                return _note.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Notes By Id  
        public IEnumerable<Note> GetNotesById(int noteId)
        {
            return _note.GetAll().Where(x => x.NoteId == noteId).ToList();
        }

        //Add Note
        public async Task<Note> AddNote(Note note)
        {
            return await _note.Create(note);
        }
        //Delete Note   
        public bool DeleteNote(int noteId)
        {
            try
            {
                var DataList = _note.GetAll().Where(x => x.NoteId == noteId).ToList();
                foreach (var item in DataList)
                {
                    _note.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
       
    }
}
