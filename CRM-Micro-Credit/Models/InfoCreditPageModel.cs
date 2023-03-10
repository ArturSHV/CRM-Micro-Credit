using CRM_Micro_Credit.Entity.Models;

namespace CRM_Micro_Credit.Models
{
	public class InfoCreditPageModel
	{
		public User User { get; set; }
		public List<Education> Educations { get; set; }
		public List<Work> Works { get; set; }
		public List<Agreement> Agreements { get; set; }
	}
}
