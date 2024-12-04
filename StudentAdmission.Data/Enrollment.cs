namespace StudentAdmission.Data
{
    public class Enrollment : BaseEntity
    {
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
