using CRM_Micro_Credit.Controllers;
using CRM_Micro_Credit.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_Micro_Credit.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ValidationCode> ValidationCodes { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agreement>().HasData(
                new Agreement
                {
                    Id= 1,
                    Name = "Настоящие условия использования сервиса",
                    Url = $"{nameof(AgreementsController)[..^10]}/Terms"
				},
				new Agreement
				{
					Id = 2,
					Name = "Политика конфиденциальности сервиса",
					Url = $"{nameof(AgreementsController)[..^10]}/Policy"
				}
				);

            modelBuilder.Entity<Work>().HasData(
                new Work 
                { 
                    Id = 1,
                    Name = "Инженер"
                },
                new Work
				{
					Id = 2,
					Name = "Менеджер"
				}
            );

            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    Id = 1,
                    Name = "Основное общее"
                },
                new Education
                {
                    Id = 2,
                    Name = "Среднее общее"
                },
                new Education
                {
                    Id = 3,
                    Name = "Среднее профессиональное"
                },
                new Education
                {
                    Id = 4,
                    Name = "Бакалавриат"
                },
                new Education
                {
                    Id = 5,
                    Name = "Специалитет, магистратура"
                });

            modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
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
