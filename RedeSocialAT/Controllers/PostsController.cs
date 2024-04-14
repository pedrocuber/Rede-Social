using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using RedeSocialAT.Data;
using RedeSocialAT.Models;
using Microsoft.AspNetCore.Authorization;

namespace RedeSocialAT.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post.Include(p => p.Perfil);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [Authorize]
        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id");
            return View();
        }
        [Authorize]
        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,PerfilId,DataPost,Texto,ImagemPost")] Post post, IFormFile ImagemPost)
        {
            if (ModelState.IsValid)
            {
                post.ImagemPost = UploadImage(ImagemPost);
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", post.PerfilId);
            return View(post);
        }
        [Authorize]
        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", post.PerfilId);
            return View(post);
        }
        [Authorize]
        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,PerfilId,DataPost,Texto,ImagemPost")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", post.PerfilId);
            return View(post);
        }
        [Authorize]
        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [Authorize]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static string UploadImage(IFormFile imageFile) {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=redesocialat;AccountKey=efr4lQk+BX9k+rtoPacYJpK3ckxxEydKYQSmKPHBIeJn2qROiX2m4LIcm+x5MNeMRSNWp//uoF81+AStv3idhA==;EndpointSuffix=core.windows.net";
            string containerName = "imagens";
            var reader = imageFile.OpenReadStream();
            var cloundStorageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = cloundStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(imageFile.FileName);
            Thread.Sleep(10000);
            blob.UploadFromStreamAsync(reader);
            return blob.Uri.ToString();

        }
        private bool PostExists(int id)
        {
          return _context.Post.Any(e => e.PostId == id);
        }
    }
}
