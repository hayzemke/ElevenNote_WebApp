using System;
namespace ElevenNote_WebApp.Shared.Models.NoteModels
{
    public class NoteListItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

