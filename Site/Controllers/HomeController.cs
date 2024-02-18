using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Generators;
//using Snapp.Core.Interfaces;
//using Snapp.Core.Services;

using Snapp.DataAccessLayer.Entites;
using Microsoft.AspNetCore.Authorization;

namespace Snapp.Site.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
