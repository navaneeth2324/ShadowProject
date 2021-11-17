using CustomerAppBL;
using CustomerAppDTO;
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
    }
}