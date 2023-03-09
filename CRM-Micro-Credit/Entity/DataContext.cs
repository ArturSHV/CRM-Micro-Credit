using CRM_Micro_Credit.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_Micro_Credit.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ValidationCode> ValidationCodes { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 2,
					Email = "mail@mail.ru",
					Mobile = "8999",
					Role = "Users",
                    AdditionalCity = "",
                    AdditionalRegion = "",
                    AdditionalPhone = "",
                    Appartment = "",
                    Area = "",
                    City = "",
                    DayOfBirth= DateTime.Now,
                    Education = "",
                    Firstname = "",
                    Gender = "",
                    House = "",
                    LastName = "",
                    MaritalStatus = "",
                    Middlename = "",
                    PassportNumber = "",
                    PlaceOfBirth = "",
                    Region = "",
                    Revenue = "",
                    SocialNumber = "",
                    Street = "",
                    ValidityPeriod = DateTime.Now,
                    Work = ""
                    
				});

		}
    }
}
