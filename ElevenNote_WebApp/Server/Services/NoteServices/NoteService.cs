using System;
using ElevenNote_WebApp.Server.Data;
using ElevenNote_WebApp.Server.Models;
using ElevenNote_WebApp.Shared.Models.NoteModels;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote_WebApp.Server.Services.NoteServices
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        private string _userID;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetUserID(string userID) => _userID = userID;

        public async Task<bool> CreateNoteAsync(NoteCreate model)
        {
            var noteEntity = new Note
            {
                Title = model.Title,
                Content = model.Content,
                OwnerID = _userID,
                CreatedUtc = DateTimeOffset.Now,
                CategoryID = model.CategoryID
            };

            _context.Notes.Add(noteEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<NoteListItem>> GetAllNotesAsync()
        {
            var noteQuery = _context
                .Notes
                .Where(n => n.OwnerID == _userID)
                .Select(n => new NoteListItem
                {
                    ID = n.ID,
                    Title = n.Title,
                    CategoryName = n.Category.Name,
                    CreatedUtc = n.CreatedUtc
                });

            return await noteQuery.ToListAsync();
        }

        public async Task<NoteDetail> GetNoteByIdAsync(int noteID)
        {
            var noteEntity = await _context
                .Notes
                .Include(nameof(Category))
                .FirstOrDefaultAsync(n => n.ID == noteID && n.OwnerID == _userID);

            if (noteEntity is null) return null;

            var detail = new NoteDetail
            {
                ID = noteEntity.ID,
                Title = noteEntity.Title,
                Content = noteEntity.Content,
                CreatedUtc = noteEntity.CreatedUtc,
                ModifiedUtc = noteEntity.ModifiedUtc,
                CategoryName = noteEntity.Category.Name,
                CategoryID = noteEntity.Category.ID,
            };

            return detail;
        }

        public async Task<bool> UpdateNoteAsync(NoteEdit model)
        {
            if (model == null) return false;

            var entity = await _context.Notes.FindAsync(model.ID);

            if (entity?.OwnerID != _userID) return false;

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.CategoryID = model.CategoryID;
            entity.ModifiedUtc = DateTimeOffset.Now;

            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteNoteAsync(int noteID)
        {
            var entity = await _context.Notes.FindAsync(noteID);
            if (entity?.OwnerID != _userID) return false;

            _context.Notes.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeleteNoteAsync(string userID)
        {
            throw new NotImplementedException();
        }
    }
}

