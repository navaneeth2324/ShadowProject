using CustomerAppBL;
using CustomerAppDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerAppAPI.Controllers
{
    public class ProductsController : ApiController
    {
        CustomerAppBLayer blObj;

        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            try
            {
                blObj = new CustomerAppBLayer();
                var result = blObj.GetProducts();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No Products Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something Went Wrong");
            }

        }
        [HttpPost]
        public HttpResponseMessage AddProduct(ProductDTO e)
        {
            try
            {

                blObj = new CustomerAppBLayer();
                var result = blObj.AddNewProduct(e);
                if (result == 1)
                {
                    //  throw new Exception();
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Added succesfully");
                }
                else if (result == -3)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product Price cannot be Null");
                }
                else if (result == -2)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product Name cannot be Null");
                }
                else if (result == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product SL NO cannot be Null");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Something Went Wrong");

                }
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "API has some exception");
            }
        }
        [HttpPut]
        public HttpResponseMessage EditProduct(ProductDTO e)
        {
            try
            {

                blObj = new CustomerAppBLayer();
                var result = blObj.UpdateProduct(e);
                if (result == 1)
                {
                    //  throw new Exception();
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Updated succesfully");
                }
                else if (result == -3)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product Price cannot be Null");
                }
                else if (result == -2)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product Name cannot be Null");
                }
                else if (result == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product SL NO cannot be Null");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Something Went Wrong");

                }
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "API has some exception");
            }
        }
    }
}
