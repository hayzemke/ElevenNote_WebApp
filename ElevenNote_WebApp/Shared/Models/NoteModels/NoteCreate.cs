using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote_WebApp.Shared.Models.NoteModels
{
    public class NoteCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryID { get; set; }
    }
}

