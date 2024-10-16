namespace FindJobsApplication.Service.IService
{
    public interface IUploadFileService
    {
        public string uploadImage(IFormFile url, string path);
        List<string> uploadListImage(IFormFileCollection images, string path);
    }
}