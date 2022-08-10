using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote_WebApp.Server.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

