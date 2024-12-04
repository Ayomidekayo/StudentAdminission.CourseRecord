using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAdmission.Data.Configuration
{
    public class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
    {
        public void Configure(EntityTypeBuilder<SchoolUser> builder)
        {
            var harser = new PasswordHasher<SchoolUser>();
            builder.HasData(new SchoolUser()
            {
                Id = "692ecad5-0d15-4bbe-9cbc-1aef283ff23e",
                Email = "schooladmin@localhost.com",
                NormalizedEmail = "SCHOOLADMIN@LOCALHOST.COM",
                NormalizedUserName = "SCHOOLADMIN@LOCALHOST.COM",
                UserName = "schooladmin@localhost.com",
                FirstName = "School",
                LastName = "Admin",
                PasswordHash = harser.HashPassword(null, "p@ssword1"),
                EmailConfirmed = true,

            }, new SchoolUser()
            {
                Id = "f5a5276d-9a51-433a-8102-de58b4c1b4ff",
                Email = "schooluser@localhost.com",
                NormalizedEmail = "SCHOOLUSER@LOCALHOST.COM",
                NormalizedUserName = "SCHOOLUSER@LOCALHOST.COM",
                UserName = "schooluser@localhost.com",
                FirstName = "School",
                LastName = "User",
                PasswordHash = harser.HashPassword(null, "p@ssword1"),
                EmailConfirmed = true,

            });
        }
    }
}