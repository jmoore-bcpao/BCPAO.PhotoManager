using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Controllers
{
   public class PhotosController : Controller
   {
      private readonly DatabaseContext _context;
      private readonly IPhotoRepository _photoRepo;
      private readonly IFileProvider _fileProvider;

      private readonly string path = @"D:\photos";

      public PhotosController(DatabaseContext context, IPhotoRepository photoRepo, IFileProvider fileProvider)
      {
         _context = context;
         _photoRepo = photoRepo;
         _fileProvider = fileProvider;
      }

      public IActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> UploadFile(IFormFile file)
      {
         if (file == null || file.Length == 0)
            return Content("file not selected");

         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", file.GetFilename());

         using (var stream = new FileStream(path, FileMode.Create))
         {
            await file.CopyToAsync(stream);
         }

         return RedirectToAction("Files");
      }

      [HttpPost]
      public async Task<IActionResult> UploadFiles(List<IFormFile> files)
      {
         if (files == null || files.Count == 0)
            return Content("files not selected");

         if (ModelState.IsValid)
         {
            foreach (var file in files)
            {
               //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", file.GetFilename());
               var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');

               using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
               {
                  using (var memoryStream = new MemoryStream())
                  {
                     await file.CopyToAsync(memoryStream);

                     var photo = new Photo
                     {
                        PropertyId = null,
                        BuildingId = null,
                        BuildingSeq = null,
                        MasterPhoto = null,
                        FrontPhoto = null,
                        PublicPhoto = null,
                        DateTaken = null,
                        ImageName = file.GetFilename(),
                        ImageSize = file.Length / 1024,
                        ImageData = memoryStream.ToArray(),
                        UserId = 1,
                        UploadedBy = User.Identity.Name.ToLower(),
                        UploadedDate = DateTime.Now,
                        Status = "Pending",
                        Active = false,
                     };

                     _photoRepo.AddPhoto(photo);
                  }
               }
            }
         }
         
         return RedirectToAction("Files");
      }

      [HttpPost]
      public async Task<IActionResult> UploadFileViaModel(FileInputModel model)
      {
         if (model == null ||
             model.FileToUpload == null || model.FileToUpload.Length == 0)
            return Content("file not selected");

         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", model.FileToUpload.GetFilename());

         using (var stream = new FileStream(path, FileMode.Create))
         {
            await model.FileToUpload.CopyToAsync(stream);
         }

         return RedirectToAction("Files");
      }

      public IActionResult Files()
      {
         var model = new FilesViewModel();

         var test = _fileProvider.GetDirectoryContents(path);

         foreach (var item in _fileProvider.GetDirectoryContents(path))
         {
            model.Files.Add(new FileDetails { Name = item.Name, Path = item.PhysicalPath, Url = path + item.Name });
         }
         return View(model);
      }

      public async Task<IActionResult> Download(string filename)
      {
         if (filename == null)
            return Content("filename not present");

         //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", filename);

         var memoryStream = new MemoryStream();
         using (var fileStream = new FileStream(path, FileMode.Open))
         {
            await fileStream.CopyToAsync(memoryStream);
         }
         memoryStream.Position = 0;
         return File(memoryStream, GetContentType(path), Path.GetFileName(path));
      }

      private string GetContentType(string path)
      {
         var types = GetMimeTypes();
         var ext = Path.GetExtension(path).ToLowerInvariant();
         return types[ext];
      }

      private Dictionary<string, string> GetMimeTypes()
      {
         return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
      }
   }
}