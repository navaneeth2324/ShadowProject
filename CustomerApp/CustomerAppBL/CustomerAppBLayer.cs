using CustomerAppDAL;
using CustomerAppDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppBL
{
    public class CustomerAppBLayer
    {
        CustomerAppDALayer dalObj;
        public CustomerAppBLayer()
        {
            dalObj = new CustomerAppDALayer();
        }
        public List<ProductDTO> GetProducts()
        {
            return dalObj.ViewProducts();
        }
        public int AddNewProduct(ProductDTO p)
        {
     
            return dalObj.AddProduct(p);
        }
        public int UpdateProduct(ProductDTO p)
        {

            return dalObj.EditProduct(p);
        }
    }
}
