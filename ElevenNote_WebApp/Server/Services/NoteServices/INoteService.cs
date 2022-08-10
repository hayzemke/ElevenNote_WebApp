using System;
using ElevenNote_WebApp.Shared.Models.NoteModels;

namespace ElevenNote_WebApp.Server.Services.NoteServices
{
    public interface INoteService
    {
        Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
        Task<bool> CreateNoteAsync(NoteCreate model);
        Task<NoteDetail> GetNoteByIdAsync(int noteID);
        Task<bool> UpdateNoteAsync(NoteEdit model);
        Task<bool> DeleteNoteAsync(int noteID);
        Task<bool> DeleteNoteAsync(string userID);
        void SetUserID(string userID);

    }
}

