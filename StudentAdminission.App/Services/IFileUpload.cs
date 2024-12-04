namespace StudentAdminission.App.Services
{
    public interface IFileUpload
    {
        string uploadStudentFile(byte[] file, string imageName);
    }
}
