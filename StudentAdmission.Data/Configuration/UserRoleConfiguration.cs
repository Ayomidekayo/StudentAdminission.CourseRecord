using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAdmission.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>()
            {
               RoleId= "e9d55997-49de-49dc-ac1d-572bc009aaad",
               UserId= "692ecad5-0d15-4bbe-9cbc-1aef283ff23e",
               
            }, new IdentityUserRole<string>()
            {
               RoleId= "2e7655dc-09f2-4b90-99a6-23d30d73ed67",
               UserId= "f5a5276d-9a51-433a-8102-de58b4c1b4ff",
            });
        }
    }
}