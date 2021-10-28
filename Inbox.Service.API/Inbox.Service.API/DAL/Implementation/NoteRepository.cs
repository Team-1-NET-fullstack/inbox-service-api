using Inbox.Service.API.DAL.Interfaces;
using Inbox.Service.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbox.Service.API.DAL.Implementation
{
    public class NoteRepository : INoteRepository<Note>
    {
        private readonly CTGeneralHospitalContext _context;

        public NoteRepository(CTGeneralHospitalContext context)
        {
            _context = context;
        }
        public Note GetNote(int id)
        {
            return _context.Notes.Where(s => s.NoteId == id).FirstOrDefault();
        }
      

        public async Task<Note> Create(Note _object)
        {
            var obj = await _context.Notes.AddAsync(_object);
            _context.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Note _object)
        {
            _context.Remove(_object);
            _context.SaveChanges();

        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        public Note GetById(int Id)
        {
            return _context.Notes.Where(s => s.NoteId == Id).FirstOrDefault();
        }

       

    }
}
