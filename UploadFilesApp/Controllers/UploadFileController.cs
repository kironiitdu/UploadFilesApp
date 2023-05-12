using Microsoft.AspNetCore.Mvc;
using UploadFilesApp.Models;

namespace UploadFilesApp.Controllers
{
    public class UploadFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MultipleFileUpload()
        {
            MultipleFilesUploadModel model = new MultipleFilesUploadModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult MultipleFileUpload(MultipleFilesUploadModel model)
        {
            if (ModelState.IsValid)
            {
               
                if (model.Files!.Count > 0)
                {
                    foreach (var file in model.Files)
                    {

                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                        //Would create folder if that does not exist
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        //Getting File path and file name
                        string fileNameWithCompletePath = Path.Combine(path, file.FileName);

                        //Saving file into directory
                        using (var stream = new FileStream(fileNameWithCompletePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                    }
                    model.Message = "File has been uploaded successfully!";
                }
                
            }

            return View("MultipleFileUpload", model);
        }

    }
}
