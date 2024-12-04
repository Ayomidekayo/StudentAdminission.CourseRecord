using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentAdmission.Data.Configuration;

namespace StudentAdmission.Data
{
    public class StudentAdministionDbContext : IdentityDbContext<SchoolUser>
    {
        public StudentAdministionDbContext(DbContextOptions<StudentAdministionDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new SchoolUserConfiguration());
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
    public class StudentAdministionDbContextFactory : IDesignTimeDbContextFactory<StudentAdministionDbContext>
    {
        public StudentAdministionDbContext CreateDbContext(string[] args)
        {
            //Get envionment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            // Build Cofig
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .Build();
            //get Connectionstring
            var optionBuilder = new DbContextOptionsBuilder<StudentAdministionDbContext>();
            var connfigurationstring = config.GetConnectionString("DefaultCon");
            optionBuilder.UseSqlServer(connfigurationstring);
            return new StudentAdministionDbContext(optionBuilder.Options);
        }
    }

}
