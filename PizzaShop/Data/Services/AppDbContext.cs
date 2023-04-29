using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Data.Services
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public static string ConnectionString { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyPhone { get; set; }
        public static string CompanyPhoneShort { get; set; }
        public static string CompanyEmail { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }//this entities will be tables in db
        public DbSet<ServiceItem> ServiceItem { get; set; }//this entities will be tables in db

        /// <summary>
        /// This method fill our db these information as default if its empty
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "73486cb6-c847-4d62-835b-80bb043b4b8f",
                Name = "admin",
                NormalizedName = "ADMIN",
            });//role for user - only admins

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "00941ba6-f8a3-4015-95e8-556e9ba3d01a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "andre@andre.com",
                NormalizedEmail ="ANDRE@ANDRE.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "passsword"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId= "f878d742-7cd6-4917-ae20-26c4692ebe58",
                UserId= "00941ba6-f8a3-4015-95e8-556e9ba3d01a"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = Guid.NewGuid(),
                CodeWord = "PageIndex",
                Title = "Main"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = Guid.NewGuid(),
                CodeWord = "PageServices",
                Title = "Our services"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = Guid.NewGuid(),
                CodeWord = "PageContacts",
                Title = "Contacts"
            });
        }
    }
}
