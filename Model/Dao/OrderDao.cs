using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        BlanketShopDbContext db = null;
        public OrderDao()
        {
            db = new BlanketShopDbContext();
        }
        public long Insert(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
