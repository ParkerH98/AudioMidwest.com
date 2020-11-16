using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioMidwest.com
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public bool ProductAvailability { get; set; }
        public int ProductInventoryQuantity { get; set; }
        public string ProductCategory { get; set; }
    }
}