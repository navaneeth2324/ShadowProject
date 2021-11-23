using CustomerAppBL;
using CustomerAppDTO;
using CustomerAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerAppMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ViewProducts()
        {
            {
                List<ProductDTO> lstProducts = new List<ProductDTO>();
                CustomerAppBLayer blObj = new CustomerAppBLayer();
                var result = blObj.GetProducts();
                foreach (var item in result)
                {
                    lstProducts.Add(new ProductDTO()
                    {

                     Sl=item.Sl,
                     ProductName=item.ProductName,
                     ProductPrice=item.ProductPrice


                    });
                }
                return View(lstProducts);

            }
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product pobj)
        {
            try
            {
                CustomerAppBLayer blObj = new CustomerAppBLayer();
                ProductDTO newpdtObj = new ProductDTO();

                newpdtObj.Sl = pobj.Sl;
                newpdtObj.ProductName = pobj.ProductName;
                newpdtObj.ProductPrice = pobj.ProductPrice;
                int result = blObj.AddNewProduct(newpdtObj);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product added successfully!!";
                    return RedirectToAction("ViewProducts");
                    
                    
                }
               
                else
                {
                    return View("CreateProduct");
                }
                
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        [HttpGet]
        public ActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProduct(Product pobj)
        {
            try
            {
                CustomerAppBLayer blObj = new CustomerAppBLayer();
                ProductDTO newpdtObj = new ProductDTO();

                newpdtObj.Sl = pobj.Sl;
                newpdtObj.ProductName = pobj.ProductName;
                newpdtObj.ProductPrice = pobj.ProductPrice;
                int result = blObj.UpdateProduct(newpdtObj);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product updated successfully!!";
                    return RedirectToAction("ViewProducts");


                }

                else
                {
                    return View("UpdateProduct");
                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
