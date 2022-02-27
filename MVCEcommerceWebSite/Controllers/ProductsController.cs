using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Services;
using MVCEcommerceWebSite.ViewModel;

namespace MVCEcommerceWebSite.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IService<Product> productService;
        private readonly IService<Category> categoryService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductsController(ApplicationDbContext context,IService<Product> ProductService, IService<Category> CategoryService, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            productService = ProductService;
            categoryService = CategoryService;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Products
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(productService.GetAll());
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
       



        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,Price,Stock,Slug,PublishAt,CreatedAt,UpdatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View();
        }
        // new product
        [HttpPost]
        public async Task<IActionResult> Create(Product ProductVM)
        {
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");

            //...
            string webRootPath = hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (files.Count != 4)
            {
                ModelState.AddModelError("Images", "Please enter All Images.");
                return View(ProductVM);
            }

            if (!ModelState.IsValid)
            {
                return View(ProductVM);
            }

            

           

            if (files.Count > 0)
            {
                foreach (var item in files)
                {
                    var uploads = Path.Combine(webRootPath, "images");
                    var extension = Path.GetExtension(item.FileName);
                    var dynamicFileName = Guid.NewGuid().ToString() + "_" + ProductVM.Id + extension;

                    using (var filesStream = new FileStream(Path.Combine(uploads, dynamicFileName), FileMode.Create))
                    {
                        item.CopyTo(filesStream);
                    }

                    //add product Image for new product
                    ProductVM.ProductImages.Add(new ProductImage { FileName = dynamicFileName });
                }
            }
            
            productService.Add(ProductVM);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
