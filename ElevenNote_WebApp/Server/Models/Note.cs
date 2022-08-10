using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote_WebApp.Server.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string OwnerID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

