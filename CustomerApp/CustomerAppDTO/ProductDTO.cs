using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppDTO
{
    public class ProductDTO
    {
        public string Sl { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
