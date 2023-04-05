using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using Resunet.ViewMapper;
using Resunet.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resunet.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthBL authBl;

        public LoginController(IAuthBL authBl)
        {
            this.authBl = authBl;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Index()
        {
            return View("Index", new LoginViewModel());
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> IndexSave(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                await authBl.Authenticate(model.Email!, model.Password!, model.RememberMe == true);
            }
            return View("Index", model);

        }
    }
}

