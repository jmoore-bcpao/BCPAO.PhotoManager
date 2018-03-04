using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BCPAO.PhotoManager.Models.ManageViewModels
{
	public class ManageLoginsViewModel
	{
		public IList<UserLoginInfo> CurrentLogins { get; set; }

		// https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/identity-2x#manageloginsviewmodel-property-change
		public IList<AuthenticationScheme> OtherLogins { get; set; }
	}
}
