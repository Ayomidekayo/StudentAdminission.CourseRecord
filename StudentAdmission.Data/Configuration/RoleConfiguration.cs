using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAdmission.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole()
            {
                Id= "e9d55997-49de-49dc-ac1d-572bc009aaad",
                Name ="Administrator",
                NormalizedName="ADMINISTRATOR"
            }, new IdentityRole()
            {
                Id= "2e7655dc-09f2-4b90-99a6-23d30d73ed67",
                Name ="User",
                NormalizedName="USER"
            });
        }
    }
}