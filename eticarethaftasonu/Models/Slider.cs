﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eticarethaftasonu.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string? Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; } = string.Empty;
        public string Context  { get; set; } = string.Empty;
        public string SliderImage { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? ResimYukle { get; set; }
    }
}
