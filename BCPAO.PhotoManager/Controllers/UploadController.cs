using Microsoft.AspNetCore.Mvc;

namespace BCPAO.PhotoManager.Controllers
{
	public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}