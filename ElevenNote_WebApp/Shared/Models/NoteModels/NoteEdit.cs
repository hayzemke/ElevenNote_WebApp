using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote_WebApp.Shared.Models.NoteModels
{
    public class NoteEdit
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}

