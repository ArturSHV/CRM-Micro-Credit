using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Micro_Credit.Entity.Models
{
	public class UserAgreement
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int AgreementId { get; set; }
		public string PageName { get; set; }
	}
}
