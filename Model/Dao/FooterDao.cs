using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class FooterDao
    {
        BlanketShopDbContext db = null;

        public FooterDao()
        {
            db = new BlanketShopDbContext();
        }
       
    }
}
