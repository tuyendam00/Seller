using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlanketShop.Models
{
    [Serializable]
    public class CartItem
    {
        public Products Product { set; get; }
        public int Quantity { set; get; }
    }
}