using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmission.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(new Course()
            {
                Id = 1,
                Title = "Minimum Api Devolopment",
                Credits = 4,
            }, new Course()
            {
                Id = 2,
                Title = "Advance Api Devolopment",
                Credits = 2,
            });
        }
    }
}