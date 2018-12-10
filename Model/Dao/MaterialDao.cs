using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MaterialDao
    {
       
            BlanketShopDbContext db = null;
            public MaterialDao()
            {
                db = new BlanketShopDbContext();
            }

            public Materials ViewDetail(long id)
            {
                return db.Materials.Find(id);
            }
        }
}
