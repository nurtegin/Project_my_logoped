using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logoped_Center.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Logoped_Center.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReceptionsController : Controller
    {
        private readonly LogopedContext _context;

        public ReceptionsController(LogopedContext context)
        {
            _context = context;
        }

        // GET: Admin/Receptions
        public async Task<IActionResult> Index()
        {
            var receptions = _context.Receptions.Include(o => o.Client);
            return View(await receptions.ToListAsync());
        }

        // GET: Admin/Receptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _context.Receptions
                .Include(o => o.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // GET: Admin/Receptions/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstName,UserId,ClientId,Status")] Reception reception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhoneId"] = new SelectList(_context.Clients, "Id", "Id", reception.ClientId);
            return View(reception);
        }

        // GET: Admin/Receptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _context.Receptions.FindAsync(id);
            if (reception == null)
            {
                return NotFound();
            }
            reception.Client = _context.Clients.FirstOrDefault(p => p.ClientId == reception.ClientId);
            //ViewData["PhoneId"] = new SelectList(_context.Phones, "Id", "Id", order.PhoneId);
            return View(reception);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FirstName,UserId,ClientId,Status")] Reception reception)
        {
            if (id != reception.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionExists(reception.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reception.ClientId);
            return View(reception);
        }

        // GET: Admin/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var reception = _context.Receptions.FirstOrDefault(p => p.Id == id);
        
            _context.Receptions.Remove(reception);
            await _context.SaveChangesAsync();
          
            return RedirectToAction(nameof(Index));
        }

     

        private bool ReceptionExists(int id)
        {
            return _context.Receptions.Any(e => e.Id == id);
        }
    }
}
