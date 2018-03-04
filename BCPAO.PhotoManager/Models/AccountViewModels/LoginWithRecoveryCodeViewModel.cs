using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.AccountViewModels
{
	public class LoginWithRecoveryCodeViewModel
    {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Recovery Code")]
            public string RecoveryCode { get; set; }
    }
}
