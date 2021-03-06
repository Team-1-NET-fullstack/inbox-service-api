using AutoMapper;
using Inbox.Service.API.BAL.Services;
using Inbox.Service.API.DAL.Implementation;
using Inbox.Service.API.DAL.Interfaces;
using Inbox.Service.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbox.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {

        private readonly NoteService _noteService;

        private readonly INoteRepository<Note> _noteRepository;

        public NoteController(INoteRepository<Note> noteRepository, NoteService noteService)
        {
            _noteService = noteService;
            _noteRepository = noteRepository;

        }

        //GET All Note by ID
        [HttpGet("GetNotesById")]
        public Object GetNotesById(int noteId)
        {
            try
            {
                var data = _noteService.GetNotesById(noteId);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //Add Notes  
        [HttpPost("AddNote")]
        public async Task<Object> AddNote([FromBody] Note note)
        {
            try
            {
                await _noteService.AddNote(note);
                return true;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        //Delete Notes  
        [HttpDelete("DeleteNote")]
        public bool DeleteNote(int noteId)
        {

            _noteService.DeleteNote(noteId);
            return true;

        }
        //GET All Notes  
        [HttpGet("GetAllNotes")]
        public Object GetAllNotes()
        {
            try
            {
                var data = _noteService.GetAllNotes();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
    
