using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Helpers;
using MVCEcommerceWebSite.Models.Entities;
using MVCEcommerceWebSite.Services;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Controllers
{
   // [Authorize]
    public class ShoppingController : Controller
    {
        private readonly IProductService productService;

        public ShoppingController(IProductService ProductService)
        {
            productService = ProductService;


        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            }
            else
            {
                cart = new List<CartItem>();

            }
            ViewBag.cart = cart;
            
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(long id)
        {
            int count = 0;
            Product productModel = productService.GetById(id);
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = productModel, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                count = cart.Count;
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = productModel, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                count = cart.Count;

            }
            return Ok(count);
            
        }

        [Route("remove/{id}")]
        [HttpPost]
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return PartialView("_CartItem");
        }

        private int isExist(long id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult AddToQuantity(long id)
        {

            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Ok();
        }
        public IActionResult MinToQuantity(long id)
        {

            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Quantity--;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Ok();

        }

    }
}
