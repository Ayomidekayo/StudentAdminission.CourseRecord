namespace StudentAdminission.App.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileUpload(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
        }
        public string uploadStudentFile(byte[] file, string imageName)
        {
           if(file == null) 
                return string.Empty; //be to path to a palceholer Image
            var folderPath = "studentPictures";
            var url = _httpContextAccessor.HttpContext.Request.Host.Value;
            var ext=Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var path = $"{_webHostEnvironment.WebRootPath}\\{folderPath}\\{fileName}";
            uploadStudentFile(file, path);
            return $"https://{url}/{folderPath}/{fileName}";
        }
        private void uploadImage(byte[] fileByte, string filepath)
        {
            FileInfo fileInfo = new(filepath);
          fileInfo?.Directory?.Create();//If the directly alreaddy exist,this method does nothing

            var fileStream = fileInfo?.Create();
               fileStream?.Write(fileByte,0,fileByte.Length);
               fileStream?.Close();
        }
    }
}
