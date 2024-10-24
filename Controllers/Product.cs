using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_Using_MVC.Models;

namespace CRUD_Using_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var products = _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString) ||
                                                p.Tags.Contains(searchString) ||
                                                p.ProductCategories.Any(pc => pc.Category.CategoryName.Contains(searchString)));
            }

            return View(products.ToList());
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                if (selectedCategories != null && selectedCategories.Length > 0)
                {
                    foreach (var categoryId in selectedCategories)
                    {
                        _context.ProductCategories.Add(new ProductCategory
                        {
                            ProductID = product.ProductID,
                            CategoryID = categoryId
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            product.SelectedCategories = product.ProductCategories.Select(pc => pc.CategoryID).ToList();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, int[] selectedCategories)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();

                var existingCategories = _context.ProductCategories.Where(pc => pc.ProductID == product.ProductID);
                _context.ProductCategories.RemoveRange(existingCategories);
                foreach (var categoryId in selectedCategories)
                {
                    _context.ProductCategories.Add(new ProductCategory
                    {
                        ProductID = product.ProductID,
                        CategoryID = categoryId
                    });
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
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
