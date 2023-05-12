using System.ComponentModel.DataAnnotations;

namespace UploadFilesApp.Models
{
    public class MultipleFilesUploadModel 
    {
        public List<IFormFile>? Files { get; set; }
        public string? Message { get; set; }
    }
}
