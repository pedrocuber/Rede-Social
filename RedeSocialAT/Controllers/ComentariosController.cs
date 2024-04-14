using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedeSocialAT.Data;
using RedeSocialAT.Models;

namespace RedeSocialAT.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comentario.Include(c => c.Post);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }
        [Authorize]
        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostId");
            return View();
        }
        [Authorize]
        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,PostId,Comment")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostId", comentario.PostId);
            return View(comentario);
        }
        [Authorize]
        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostId", comentario.PostId);
            return View(comentario);
        }
        [Authorize]
        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,PostId,Comment")] Comentario comentario)
        {
            if (id != comentario.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.CommentId))
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
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostId", comentario.PostId);
            return View(comentario);
        }
        [Authorize]
        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }
        [Authorize]
        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comentario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Comentario'  is null.");
            }
            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentario.Remove(comentario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(int id)
        {
          return _context.Comentario.Any(e => e.CommentId == id);
        }
    }
}
