namespace CRM_Micro_Credit.Interfaces
{
    public interface IValidationCode
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }
}
