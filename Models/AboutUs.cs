using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace LawFirmTemplate.Models
{

    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Paragraph1 { get; set; }

        public string? Paragraph2 { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

         
    }

}


