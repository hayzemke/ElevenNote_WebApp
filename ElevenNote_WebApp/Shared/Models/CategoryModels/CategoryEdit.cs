using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote_WebApp.Shared.Models.CategoryModels
{
    public class CategoryEdit
    {
        [Required]
        public string Name { get; set; }
    }
}

