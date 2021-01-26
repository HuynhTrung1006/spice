using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Spice.Data;
using Spice.Models;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //get
        public async Task<IActionResult> Index()
        {
            return View(await _db.Category.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category cate)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(cate);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(cate);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var cate = await _db.Category.FindAsync(id);
            if(cate==null)
            {
                return NotFound();
            }

            return View(cate);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category cate)
        {
            if(ModelState.IsValid)
            {
                _db.Update(cate);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(cate);

        }

        public async Task<IActionResult> Delete(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            var cate = await _db.Category.FindAsync(id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var cate =await _db.Category.FindAsync(id);

            if(cate==null)
            {
                return View(cate);
            }

            _db.Category.Remove(cate);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var cate = await _db.Category.FindAsync(id);
            if(cate==null)
            {
                return NotFound();
            }

            return View(cate);
        }
    }
}
