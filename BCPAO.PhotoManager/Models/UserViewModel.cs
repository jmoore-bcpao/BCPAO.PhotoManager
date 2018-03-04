﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models
{
	public class UserViewModel
    {
		public UserViewModel()
		{
			RoleIds = new List<int>();
		}

		public int Id { get; set; }
		
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Display(Name = "Password")]
		public string Password { get; set; }

		public List<int> RoleIds { get; set; }
	}
}
