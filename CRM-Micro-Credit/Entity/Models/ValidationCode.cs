

namespace CRM_Micro_Credit.Entity.Models
{
    public class ValidationCode 
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }
}
