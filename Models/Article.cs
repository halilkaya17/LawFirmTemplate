﻿using System.ComponentModel.DataAnnotations;

namespace LawFirmTemplate.Models
{
    
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string CardDescription { get; set; }

        public string CardImage { get; set; }

        public string FullImage { get; set; }

        public string Paragraph1 { get; set; }
       
    }
}
