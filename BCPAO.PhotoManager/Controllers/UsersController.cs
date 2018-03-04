using BCPAO.PhotoManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BCPAO.PhotoManager.Controllers
{
	public class UsersController : BaseController
	{
		public UsersController(IPhotoRepository repo) : base(repo)
		{
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
