using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BCPAO.PhotoManager.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(IPhotoRepository repo) : base(repo)
		{
		}

		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
