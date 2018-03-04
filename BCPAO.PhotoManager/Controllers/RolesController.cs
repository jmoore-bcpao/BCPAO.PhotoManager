﻿using AutoMapper;
using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Data.Entities;
using BCPAO.PhotoManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Controllers
{
	public class RolesController : BaseController
	{
		private readonly IMapper _mapper;

		public RolesController(
			UserManager<User> userManager, 
			DatabaseContext context, 
			IPhotoRepository repo, 
			RoleManager<Role> roleManager,
			IMapper mapper) : base(userManager, roleManager, context, repo) 
			{
				_mapper = mapper;
			}

		public async Task<IActionResult> Index()
		{
			//if (!HasPermission("VIEW_ROLES"))
			//{
			//    return Unauthorized();
			//}

			var roles = _roleManager.Roles;
			return View(await roles.Include(r => r.RolePermissions).ToListAsync());
		}

		public async Task<IActionResult> Details(int? id)
		{
			//if (!HasPermission("VIEW_ROLES"))
			//{
			//    return Unauthorized();
			//}

			if (id == null)
			{
				return NotFound();
			}

			var role = await _roleManager.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(r => r.Id == id);

			if (role == null)
			{
				return NotFound();
			}

			return View(role);
		}

		public IActionResult Create()
		{
			//if (!HasPermission("CREATE_ROLES"))
			//{
			//    return Unauthorized();
			//}

			//ViewBag.PermissionGroups = PermissionGroup.GetList();
			//ViewBag.Permissions = _context.Permissions.ToList().ToListViewModel();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(RoleViewModel model)
		{
			//if (!HasPermission("CREATE_ROLES"))
			//{
			//    return Unauthorized();
			//}

			//if (ModelState.IsValid)
			//{
			//	//var role = model.ToEntity();
			//	var role = _mapper.Map<Role, RoleViewModel>(model);

			//	var result = await _roleManager.CreateAsync(role);

			//	if (result.Succeeded)
			//	{
			//		return RedirectToAction("Index");
			//	}
			//	else
			//	{
			//		AddErrors(result);
			//	}
			//}

			//ViewBag.PermissionGroups = PermissionGroup.GetList();
			//ViewBag.Permissions = _context.Permissions.ToList().ToListViewModel();

			return View(model);
		}

		public IActionResult Edit(int? id)
		{
			//if (!HasPermission("EDIT_ROLES"))
			//{
			//    return Unauthorized();
			//}

			//if (id == null)
			//{
			//	return NotFound();
			//}

			//var role = await _roleManager.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(r => r.Id == id.Value);

			//if (role == null)
			//{
			//	return NotFound();
			//}

			//ViewBag.PermissionGroups = PermissionGroup.GetList();
			//ViewBag.Permissions = _context.Permissions.ToList().ToListViewModel();

			//return View(role.ToViewModel());
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(RoleViewModel model)
		{
			//if (!HasPermission("EDIT_ROLES"))
			//{
			//    return Unauthorized();
			//}

			//var role = await _roleManager.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(r => r.Id == model.Id);

			//if (role == null)
			//{
			//	return NotFound();
			//}

			//if (ModelState.IsValid)
			//{
			//	role = model.UpdateEntity(role);

			//	var result = await _roleManager.UpdateAsync(role);

			//	if (result.Succeeded)
			//	{
			//		return RedirectToAction("Index");
			//	}
			//	else
			//	{
			//		AddErrors(result);
			//	}
			//}

			//ViewBag.PermissionGroups = PermissionGroup.GetList();
			//ViewBag.Permissions = _context.Permissions.ToList().ToListViewModel();

			return View(model);
		}

		[ActionName("Delete")]
		public async Task<IActionResult> Delete(int? id)
		{
			//if (!HasPermission("DELETE_ROLES"))
			//{
			//    return Unauthorized();
			//}

			if (id == null)
			{
				return NotFound();
			}

			var role = await _roleManager.FindByIdAsync(id.ToString());

			if (role == null)
			{
				return NotFound();
			}

			return View(role);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			//if (!HasPermission("DELETE_ROLES"))
			//{
			//    return Unauthorized();
			//}

			var role = await _roleManager.FindByIdAsync(id.ToString());

			await _roleManager.DeleteAsync(role);

			return RedirectToAction("Index");
		}
	}
}
