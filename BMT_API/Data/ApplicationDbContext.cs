using BMT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMT_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Firstname = "John",
                    Lastname = "Doe",
                    CompanyName = "ABC Company",
                    Mobile = "099824788822",
                    Email = "johndoe@abc.com"
                },
              new Contact
              {
                  Id = 2,
                  Firstname = "Jane",
                  Lastname = "Doe",
                  CompanyName = "ABC Company",
                  Mobile = "099924781211",
                  Email = "janedoe@abc.com"
              },
              new Contact
              {
                  Id = 3,
                  Firstname = "Juan",
                  Lastname = "Dela Cruz",
                  CompanyName = "JDC Company",
                  Mobile = "099824781111",
                  Email = "juandelacruz@jdc.com"
              });

            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser
                {
                    Id = 1,
                    UserName = "admin",
                    Name = "Admin",
                    Password = "admin123",
                    Role = "admin"
                });
        }
    }
}
