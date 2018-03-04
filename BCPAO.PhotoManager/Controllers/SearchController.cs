using BCPAO.PhotoManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BCPAO.PhotoManager.Controllers
{
	public class SearchController : BaseController
    {
		public SearchController(IPhotoRepository repo) : base(repo)
		{
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
