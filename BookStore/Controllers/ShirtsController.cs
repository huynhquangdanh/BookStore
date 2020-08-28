using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly BookStoreContext _context;

        public ShirtsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Tshirts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tshirt.ToListAsync());
        }

        // GET: Tshirts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tshirt = await _context.Tshirt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tshirt == null)
            {
                return NotFound();
            }

            return View(tshirt);
        }

        // GET: Tshirts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tshirts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Brand,Price,PublishDate")] Shirt tshirt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tshirt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tshirt);
        }

        // GET: Tshirts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tshirt = await _context.Tshirt.FindAsync(id);
            if (tshirt == null)
            {
                return NotFound();
            }
            return View(tshirt);
        }

        // POST: Tshirts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Brand,Price,PublishDate")] Shirt tshirt)
        {
            if (id != tshirt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tshirt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TshirtExists(tshirt.Id))
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
            return View(tshirt);
        }

        // GET: Tshirts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tshirt = await _context.Tshirt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tshirt == null)
            {
                return NotFound();
            }

            return View(tshirt);
        }

        // POST: Tshirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tshirt = await _context.Tshirt.FindAsync(id);
            _context.Tshirt.Remove(tshirt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TshirtExists(int id)
        {
            return _context.Tshirt.Any(e => e.Id == id);
        }
    }
}
