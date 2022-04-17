using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController:BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
