using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Spice.Data;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItem : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MenuItem(ApplicationDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _hostingEnvironment = host;
        }
        public async Task<IActionResult> Index()
        {
            var menuitem = await _db.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();

            return View(menuitem);
        }
    }
}
