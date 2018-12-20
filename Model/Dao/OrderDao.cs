using Model.EF;
using Model.ViewModel;
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

        public List<OrderDetailsModel> getProductDetailsList(long id)
        {
           var model = (from od in db.OrderDetails
                         join pd in db.Products on od.ProductID equals pd.ID
                         join m in db.Materials on pd.Material_id equals m.Material_id
                         join s in db.Sizes on pd.Size_id equals s.Size_id
                         join c in db.Colors on pd.Color_id equals c.Color_id
                         join ctr in db.Contries on pd.Contry_id equals ctr.Country_id
                         where od.OrderID == id
                         select new
                         {
                             pd.Name,
                             m.Material_name,
                             c.Color_name,
                             s.Size_name,
                             ctr.Country_name,
                             pd.Price,
                             od.Quantity
                         }).AsEnumerable().Select(x => new OrderDetailsModel()
                         {
                             ProductName = x.Name,
                             MaterialName = x.Material_name,
                             ColorName = x.Color_name,
                             SizeName = x.Size_name,
                             CountryName = x.Country_name,
                             Price = x.Price.Value,
                             Quantity = x.Quantity.Value
                         });
            return model.ToList();
        }
    }
}
