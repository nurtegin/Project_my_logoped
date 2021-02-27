using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Logoped_Center.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Logoped_Center.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly LogopedContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClientsController(LogopedContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Phones
        public async Task<IActionResult> Index(string search)
        {
            List<Client> clients;
            if (search != null)
            {
                clients = await _context.Clients.Where(p => p.FirstName.Contains(search)).ToListAsync();
            }
            else
            {
                clients = await _context.Clients.ToListAsync();
            }
            return View(clients);
        }

        // GET: Admin/Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }



        // POST: Admin/Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id)
        {
            var client = _context.Clients.FirstOrDefault(p => p.ClientId == id);

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
