using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.AccountViewModels
{
	public class ForgotPasswordViewModel
    {
		[Required]
		[Display(Name = "Email Address")]
		public string Email { get; set; }
	}
}
