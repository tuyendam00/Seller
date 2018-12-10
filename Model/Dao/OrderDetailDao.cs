using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        BlanketShopDbContext db = null;
        public OrderDetailDao()
        {
            db = new BlanketShopDbContext();
        }
        public bool Insert(OrderDetails detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                var e = ex.Message;
                return false;
            }

        }
    }
}
