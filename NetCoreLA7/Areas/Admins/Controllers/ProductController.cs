using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using global::NetCoreLA7.Data;
using global::NetCoreLA7.Models;

namespace NetCoreLA7.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admins/Product
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Include(p => p.Category).OrderByDescending(p => p.Id);
            return View(await products.ToListAsync());
        }

        // GET: Admins/Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admins/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (await _context.Products.AnyAsync(p => p.Name == product.Name))
            {
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại!");
            }

            if (product.SalePrice > product.Price)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn hoặc bằng giá gốc!");
            }

            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admins/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admins/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();

            if (await _context.Products.AnyAsync(p => p.Name == product.Name && p.Id != id))
            {
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại!");
            }

            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admins/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Admins/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}