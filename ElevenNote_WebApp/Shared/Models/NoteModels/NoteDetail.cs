using System;
namespace ElevenNote_WebApp.Shared.Models.NoteModels
{
    public class NoteDetail
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}

