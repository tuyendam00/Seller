using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ColorDao
    {
        BlanketShopDbContext db = null;
        public ColorDao()
        {
            db = new BlanketShopDbContext();
        }

        public Colors ViewDetail(long id)
        {
            return db.Colors.Find(id);
        }
    }
}
