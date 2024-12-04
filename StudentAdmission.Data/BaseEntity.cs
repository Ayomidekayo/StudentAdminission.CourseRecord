namespace StudentAdmission.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }=string.Empty;
        public string MordifiedBy { get; set; }=string.Empty ;
        public DateTime MordifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
