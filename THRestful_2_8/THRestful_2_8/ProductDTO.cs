using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THRestful_2_8
{
    public class ProductDTO
    {
        public int productID { get; set; }  
        public string productName { get; set; }  
        public decimal price { get; set; }  
        public string categoryName { get; set; }  
        
    }
}