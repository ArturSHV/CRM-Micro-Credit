using System.ComponentModel.DataAnnotations;

namespace CRM_Micro_Credit.Interfaces
{
    public interface ILogin
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
        public string ValidationCode { get; set; }
    }
}
