using System.ComponentModel.DataAnnotations;

namespace LawFirmTemplate.Models
{
  
    public class PracticeAreas
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Paragraph1 { get; set; }

        public string Paragraph2 { get; set; }

        public string Paragraph3 { get; set; }

        public string Paragraph4 { get; set; }

        public string Icon { get; set; }

        public string Image { get; set; }
    }
}
