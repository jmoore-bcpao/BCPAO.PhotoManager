using BCPAO.PhotoManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BCPAO.PhotoManager.Controllers
{
   public class TagController : BaseController
   {
      public TagController(IPhotoRepository repo) : base(repo)
      {

      }

      public IActionResult Index()
      {
         return View();
      }
   }
}