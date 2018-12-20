using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderDetailsModel
    {
        public string ProductName { get; set; }
        public string MaterialName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string CountryName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
