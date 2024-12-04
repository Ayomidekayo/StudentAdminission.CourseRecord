namespace StudentAdmission.Data
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<Enrollment> Enrollment { get; set; } = new List<Enrollment>();
    }
}
