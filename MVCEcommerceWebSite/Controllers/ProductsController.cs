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
using MVCEcommerceWebSite.Models.Entities;
using MVCEcommerceWebSite.Services;
using MVCEcommerceWebSite.ViewModel;

namespace MVCEcommerceWebSite.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService productService;
        private readonly ICategoriesService categoryService;
        private readonly IColorsService colorsService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductsController(ApplicationDbContext context,IProductService ProductService, ICategoriesService CategoryService, IColorsService ColorsService, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            productService = ProductService;
            categoryService = CategoryService;
            colorsService = ColorsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region Get Products
        // GET: Products
        public IActionResult Index()
        {
            ViewBag.Colors = new SelectList(colorsService.GetAll(), "Id", "Color");
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");

            return View(productService.GetAll());
        }
        #endregion 

        #region Get Details Of ProductById

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewData["categories"] = categoryService.GetAll();
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["fourProduct"]= productService.GetAll().Take(4).ToList();
            return View(product);
        }
        #endregion 


        #region Edit Product By Id




        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        #endregion

        #region Delete Products
        [Authorize(Roles = "Admin")]
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
        #endregion


        #region Create Product
        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            ViewBag.Colors = new SelectList(colorsService.GetAll(), "Id", "Color");
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View();
        }
        // new product
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product ProductVM,int[] SelectedIds)
        {
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            ViewBag.Colors = new SelectList(colorsService.GetAll(), "Id", "Color");

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
                    ProductVM.ProductImages.Add(new ProductImage { FileName = dynamicFileName,FilePath= $"/images/{dynamicFileName}" });
                }
            }

            List<Colors> ColorsNew = new List<Colors>();
            foreach (var colorId in SelectedIds)
            {
                //Colors color = new Colors();
                //colorsService.Add(colorsService.GetById(colorId));
                ColorsNew.Add(colorsService.GetById(colorId));
            }
            
            ProductVM.Colors = ColorsNew;

            productService.Add(ProductVM);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Ajax
        [HttpPost]
        public IActionResult ShopByColors(int[] selectedColors )
        {
            
            return PartialView(productService.GetProductsByColors(selectedColors));
        }
        [HttpPost]
        public IActionResult ShopByPrice(int min,int max)
        {
            return PartialView("ShopByColors", productService.GetProductsByPrice(min,max));

        }
        
        public IActionResult ShopByCategory(int[] Categorys)
        {
            if (Categorys.Length == 1 && Categorys[0] == 0)
            {
                return PartialView("ShopByColors", productService.GetAll());
            }
            else {
                return PartialView("ShopByColors", productService.GetProductsByCategory(Categorys));
            }
          

        }
        public IActionResult ShopByCategoryHome(int[] Categorys)
        {
            if (Categorys.Length == 1 && Categorys[0] == 0)
            {
                return PartialView("_Shop", productService.GetAll());
            }
            else
            {
                return PartialView("_Shop", productService.GetProductsByCategory(Categorys));
            }


        }



        #endregion

    }
}
