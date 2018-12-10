using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        BlanketShopDbContext db = null;
        public CategoryDao()
        {
            db = new BlanketShopDbContext();
        }
        public List<Categories> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public Categories ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }
        public bool CheckExistProductInCategory(long categoryId)
        {
            return (db.Products.FirstOrDefault(m => m.Category_id == categoryId) == null);
        }
    }
}
