using CustomerAppBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerAppBLayer blObj = new CustomerAppBLayer();
            Console.WriteLine("---------------Products--------------------");
            var finalresult = blObj.GetProducts();
            foreach (var item in finalresult)
            {

                Console.WriteLine("SL NO: "+item.Sl+" Product Name: "+item.ProductName+" Product Price: "+item.ProductPrice);
            }
        }
    }
}
