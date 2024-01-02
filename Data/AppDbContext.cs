using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
       
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        private string dbPath { get; set; }
       

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = System.IO.Path.Join(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={dbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRole = new IdentityRole() { Name = "admin", NormalizedName = "ADMIN1", Id = Guid.NewGuid().ToString() };
            adminRole.ConcurrencyStamp = adminRole.Id;
            var userRole = new IdentityRole() { Name = "user", NormalizedName = "USER1", Id = Guid.NewGuid().ToString() };
            userRole.ConcurrencyStamp = userRole.Id;

            modelBuilder.Entity<IdentityRole>().HasData(
                adminRole,
                userRole
            );

            var hash = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser() { UserName = "adam", NormalizedUserName = "ADAM", Email = "adam@wsei.edu.pl", NormalizedEmail = "ADAM@WSEI.EDU>PL", EmailConfirmed = true, Id = Guid.NewGuid().ToString() };
            var normalUser = new IdentityUser() { UserName = "marcin", NormalizedUserName = "MARCIN", Email = "marcin@wsei.edu.pl", NormalizedEmail = "MARCIN@WSEI.EDU>PL", EmailConfirmed = true, Id = Guid.NewGuid().ToString() };
            adminUser.PasswordHash = hash.HashPassword(adminUser, "1234ABCDabcd!@#$");
            normalUser.PasswordHash = hash.HashPassword(normalUser, "1234ABCDabcd!@#$");

            modelBuilder.Entity<IdentityUser>().HasData(
                adminUser,
                normalUser
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = adminRole.Id, UserId = adminUser.Id },
                new IdentityUserRole<string>() { RoleId = userRole.Id, UserId = normalUser.Id }
            );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(contact => contact.Organization)
                .WithMany(organization => organization.Contacts)
                .HasForeignKey(contact => contact.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity() { Id = 1, Name = "WSEI", Description = "Uczelnia wyższa" },
                new OrganizationEntity() { Id = 2, Name = "PKP", Description = "Przewoźnik kolejowy" }
            );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { ContactId = 1, OrganizationId = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1 },
                new ContactEntity() { ContactId = 2, OrganizationId = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2 }
            );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(organization => organization.Address)
                .HasData(
                    new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150" },
                    new { OrganizationEntityId = 2, City = "Kraków", Street = "Dworcowa 5", PostalCode = "31-699" }
                );

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity() { Id = 1, Content = "przykladowa zawartosc", Author = "Andzej", PublicationDate = new DateTime(2000, 10, 10), Tags = "Tagi fsafa", Comment = "Pierwszyt komenttarz" },
                new PostEntity() { Id = 2, Content = "przykladowa druga zawartosc", Author = "Maciek", PublicationDate = new DateTime(2020, 11, 10), Tags = "Tagi dwa", Comment = "Drugi komenttarz" }
            );
        }
    }
}
