﻿using System;
using Resunet.BL.Auth;
using Microsoft.AspNetCore.Mvc;
using Resunet.ViewModels;
using Resunet.DAL;
using Resunet.ViewMapper;
namespace Resunet.Controllers
{
	public class RegisterController :Controller
	{
		private readonly IAuthBL authBl;

		public RegisterController(IAuthBL authBl)
		{
			this.authBl = authBl;
		}

		[HttpGet]
		[Route("/register")]
		public IActionResult Index()
		{
			return View("Index", new RegisterViewModel());
		}

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult>IndexSave(RegisterViewModel model)
        {
			if (ModelState.IsValid)
			{
				await authBl.CreateUser(AuthMapper.MapRegisterVIewModelToUserModel(model));
				return Redirect("/");
			}
			return View("Index", model);

        } 
    }
}

 