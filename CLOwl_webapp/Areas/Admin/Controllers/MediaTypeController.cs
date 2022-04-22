using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClowlWebApp.Data;
using ClowlWebApp.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClowlWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MediaTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MediaTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<IActionResult> StandardCRUDIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.MediaType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/MediaType
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaType.ToListAsync());
        }

        // GET: Admin/MediaType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return await StandardCRUDIndex(id);
        }

        // GET: Admin/MediaType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MediaType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ThumbnailImagePath")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaType);
        }

        // GET: Admin/MediaType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await StandardCRUDIndex(id);
        }

        // POST: Admin/MediaType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ThumbnailImagePath")] MediaType mediaType)
        {
            if (id != mediaType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaTypeExists(mediaType.Id))
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
            return View(mediaType);
        }

        // GET: Admin/MediaType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return await StandardCRUDIndex(id);
        }

        // POST: Admin/MediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaType = await _context.MediaType.FindAsync(id);
            _context.MediaType.Remove(mediaType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaTypeExists(int id)
        {
            return _context.MediaType.Any(e => e.Id == id);
        }
    }
}
