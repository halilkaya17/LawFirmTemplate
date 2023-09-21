using LawFirmTemplate.Models;

namespace LawFirmTemplate.ViewModels
{
    public class HomeViewModel
    {
        public List<Article> Articles { get; set; }

        public List<OurTeam> OurTeams { get; set; }

        public List<PracticeAreas> PracticeAreas { get; set; }

        public HomePage HomePage { get; set; }

        public Slider Slider { get; set; }

        public GeneralSetting  GeneralSetting { get; set; }

    }
}
