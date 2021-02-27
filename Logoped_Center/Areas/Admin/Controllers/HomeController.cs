using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using Microsoft.EntityFrameworkCore;
using Logoped_Center.Models;

namespace Logoped_Center.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly LogopedContext _context;

        public HomeController(LogopedContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
               return View();
        }
    }
}
