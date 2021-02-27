using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logoped_Center.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Logoped_Center.Controllers
{
    public class ClientsController : Controller
    {
 
        private readonly LogopedContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> userManager;

        public ClientsController(LogopedContext context, RoleManager<IdentityRole> roleManager, UserManager<User> USERmanager)
        {
            _context = context;
            _roleManager = roleManager;
            userManager = USERmanager;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
               
            return View(_context.Users.ToList());
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }


        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }
    }
}
