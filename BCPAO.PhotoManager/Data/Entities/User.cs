using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BCPAO.PhotoManager.Data.Entities
{
	public class User : IdentityUser<int>
	{
		public User() : base()
		{
			Photos = new HashSet<Photo>();
			UserPermissions = new HashSet<UserPermission>();
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime CreateDate { get; set; }
		public UserProfile Profile { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }
		public virtual ICollection<UserPermission> UserPermissions { get; set; }
		
		// Add IdentityUser POCO Navigation Properties
		// docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/identity-2x
		public virtual ICollection<IdentityUserRole<int>> Roles { get; } = new List<IdentityUserRole<int>>();
		public virtual ICollection<IdentityUserClaim<int>> Claims { get; } = new List<IdentityUserClaim<int>>();
		public virtual ICollection<IdentityUserLogin<int>> Logins { get; } = new List<IdentityUserLogin<int>>();
	}
}