using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ProductController()
        {

        }

        public ActionResult ProductManagement()
        {
            return View();
        }
        
        public JsonResult GetProducts()
        {
            var productsList = db.prdc.ToList();
            var products = productsList.Select(b => new
            {
                Id = b.Id,
                ProductCode = b.ProductCode,
                PrmoductName = b.PrmoductName,
                Description = b.Description,
                Price = b.Price,
                Type = b.Type,
                ExpiryDate = b.ExpiryDate.ToString()
            }).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult SearchProduct(string searchString)
        {
            var productModel = db.prdc.Where(b => b.PrmoductName.ToLower().Contains(searchString.ToLower()) || b.ProductCode.ToLower().Contains(searchString.ToLower())).FirstOrDefault();

            var product = new
            {
                Id = productModel.Id,
                ProductCode = productModel.ProductCode,
                PrmoductName = productModel.PrmoductName,
                Description = productModel.Description,
                Price = productModel.Price,
                Type = productModel.Type,
                ExpiryDate = productModel.ExpiryDate.ToString()
            };

            return Json(product, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult CreateNew(Product model)
        {
            try
            {
                db.prdc.Add(model);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch
            {
                throw;
            }
            return Json(new { success = false });
        }

        
    }
}