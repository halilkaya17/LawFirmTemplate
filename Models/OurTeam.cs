using System.ComponentModel.DataAnnotations;

namespace LawFirmTemplate.Models
{
    
    public class OurTeam
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string PreDescription { get; set; }

        public string Description { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public int IsActive { get; set; }
    }
}
