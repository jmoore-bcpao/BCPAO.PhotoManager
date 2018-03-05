using Microsoft.AspNetCore.Http;

namespace BCPAO.PhotoManager.Models
{
   public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
