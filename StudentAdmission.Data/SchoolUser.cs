using Microsoft.AspNetCore.Identity;

namespace StudentAdmission.Data
{
    public class SchoolUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
