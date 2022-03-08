using Microsoft.AspNetCore.Mvc;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using MVCEcommerceWebSite.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace MVCEcommerceWebSite.Controllers
{
    public class DashbordController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService productService;
        private readonly ICategoriesService categoryService;
        private readonly IColorsService colorsService;
        private readonly IDashbordServices _dashbordServices;
       

        public DashbordController(ApplicationDbContext context, IProductService ProductService, ICategoriesService CategoryService, IColorsService ColorsService,IDashbordServices dashbordServices)
        {
            _context = context;
            productService = ProductService;
            categoryService = CategoryService;
            _dashbordServices = dashbordServices;
            colorsService = ColorsService;
   
        }
        public IActionResult Index()
        {
           List<SellerUser> list= _dashbordServices.GetAll(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Product> productslist = new List<Product>();
            foreach (var item in list)
            {

                productslist.Add(productService.GetById(item.productid));
                    }
            return View(productslist);
        }
    }
}
