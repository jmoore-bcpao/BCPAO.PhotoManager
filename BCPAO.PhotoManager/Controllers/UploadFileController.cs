using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BCPAO.PhotoManager.Controllers
{
	public class UploadFileController : BaseController
	{
		private readonly IHostingEnvironment _env;
		private readonly IConfiguration _config;

		public UploadFileController(
			UserManager<User> userManager, 
			IPhotoRepository repo, 
			IHostingEnvironment env, 
			IConfiguration config) :base(userManager, repo)
		{
			_env = env;
			_config = config;
		}

	}
}
