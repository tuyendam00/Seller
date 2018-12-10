using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CountryDao
    {
        BlanketShopDbContext db = null;
        public CountryDao()
        {
            db = new BlanketShopDbContext();
        }

        public Contries ViewDetail(long id)
        {
            return db.Contries.Find(id);
        }
    }
}
