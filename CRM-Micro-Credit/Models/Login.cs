using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Micro_Credit.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите номер телефона")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Укажите почту")]
        public string Email { get; set; }
        public string? ReturnUrl { get; set; }
        public string? ValidationCode { get; set; }
    }
}
