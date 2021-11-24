using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppDTO
{
    public class ProductDTO
    {
        [DisplayName("SL NO")]
        public string Sl { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Price ")]
        public int ProductPrice { get; set; }
    }
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
