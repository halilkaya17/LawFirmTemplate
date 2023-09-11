using System.ComponentModel.DataAnnotations;

namespace LawFirmTemplate.Models
{
    
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string CardDescription { get; set; }

        public string Paragraph1 { get; set; }

        public string Paragraph2 { get; set; }

        public string Paragraph3 { get; set; }

        public string Paragraph4 { get; set; }

        public string Paragraph5 { get; set; }

        public string CardImage { get; set; }

        public string FullImage { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string Category { get; set; }

        public bool IsActive { get; set; }
    }
}
