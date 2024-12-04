namespace StudentAdmission.Data
{
    public class Student :BaseEntity
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IsNumber { get; set; }
        public string Picture { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string OriginalFileName { get; set; }

        public List<Enrollment> Enrollment { get; set; }=new List<Enrollment>();
    }
    }

