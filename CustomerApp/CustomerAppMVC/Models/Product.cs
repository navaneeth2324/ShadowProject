using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerAppMVC.Models
{
    public class Product
    {
        [DisplayName("SL NO")]
        public string Sl { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Price")]
        public int ProductPrice { get; set; }
    }
}