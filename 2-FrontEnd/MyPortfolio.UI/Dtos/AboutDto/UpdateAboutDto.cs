using Microsoft.Build.Framework;

namespace MyPortfolio.UI.Dtos.AboutDto
{
	public class UpdateAboutDto
	{
		public int AboutID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
