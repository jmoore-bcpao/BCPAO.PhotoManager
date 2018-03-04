﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BCPAO.PhotoManager.Data.Entities
{
	public class Role : IdentityRole<int>
	{
		public Role() : base()
		{
			RolePermissions = new HashSet<RolePermission>();
		}

		public Role(string role) : base()
		{
			RolePermissions = new HashSet<RolePermission>();
		}

		public virtual ICollection<RolePermission> RolePermissions { get; set; }
	}
}
