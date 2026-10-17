using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using global::NetCoreLA7.Data;
using global::NetCoreLA7.Models;

namespace NetCoreLA7.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // 1. HIỂN THỊ DANH SÁCH (GET: Admins/Category)
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.OrderByDescending(c => c.Id).ToListAsync();
            return View(categories);
        }

        // 2. XEM CHI TIẾT (GET: Admins/Category/Details/5)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // 3. THÊM MỚI - GIAO DIỆN (GET: Admins/Category/Create)
        public IActionResult Create()
        {
            return View();
        }

        // 3. THÊM MỚI - XỬ LÝ LƯU (POST: Admins/Category/Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            // Kiểm tra trùng tên danh mục
            if (await _context.Categories.AnyAsync(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Tên danh mục này đã tồn tại!");
            }

            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // 4. CẬP NHẬT - GIAO DIỆN (GET: Admins/Category/Edit/5)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // 4. CẬP NHẬT - XỬ LÝ LƯU (POST: Admins/Category/Edit/5)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id) return NotFound();

            // Kiểm tra trùng tên với các danh mục khác
            if (await _context.Categories.AnyAsync(c => c.Name == category.Name && c.Id != id))
            {
                ModelState.AddModelError("Name", "Tên danh mục này đã tồn tại!");
            }

            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // 5. XÓA - XÁC NHẬN (GET: Admins/Category/Delete/5)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // 5. XÓA - THỰC HIỆN (POST: Admins/Category/Delete/5)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}