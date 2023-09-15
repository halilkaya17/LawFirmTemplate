using LawFirmTemplate.Models;

namespace LawFirmTemplate.ViewModels
{
	public class NavbarViewModel
	{
        public GeneralSetting generalSetting { get; set; }

        public List<PracticeAreas> practiceAreas { get; set; }
    }
}
