using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class MenuDao
    {
        BlanketShopDbContext db = null;
        public MenuDao()
        {
            db = new BlanketShopDbContext();
        }
        public List<Menu> ListByGroupId(int groupid)
        {
            return db.Menu.Where(x => x.TypeID == groupid && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
