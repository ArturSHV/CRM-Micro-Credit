using CRM_Micro_Credit.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Micro_Credit.Entity.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; } = "Users";
        [NotMapped]
        public string ReturnUrl { get; set; }

        [NotMapped]
        public string ValidationCode { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? SocialNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? ValidityPeriod { get; set; }
        public string? Area { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Appartment { get; set; }
        public string? Work { get; set; }
        public string? Education { get; set; }
        public string? Revenue { get; set; }
        public string? AdditionalPhone { get; set; }
        public string? AdditionalRegion { get; set; }
        public string? AdditionalCity { get; set; }
    }
}
