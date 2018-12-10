using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        BlanketShopDbContext db = null;
        public SlideDao()
        {
            db = new BlanketShopDbContext();
        }
        public List<Slides> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
