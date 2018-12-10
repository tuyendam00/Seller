using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        BlanketShopDbContext db = null;
        public ProductDao()
        {
            db = new BlanketShopDbContext();
        }
        public List<Products> ListNewProduct(int top)
        {
            return db.Products.OrderBy(x => x.CreatedDate).Take(top).ToList();

        }

        


        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();

        }

        /// <summary>
        /// get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Category_id == categoryID).Count();
            var model = (from a in db.Products
                        join b in db.Categories
                        on a.Category_id equals b.ID
                        where a.Category_id == categoryID
                        select new
                        {
                            CateMetaTitle = b.MetaTitle,
                            CateName = b.Name,
                            CreatedDate = a.CreatedDate,
                            ID = a.ID,
                            Images = a.Image,
                            Name = a.Name,
                            MetaTitle = a.MetaTitle,
                            Price = a.Price
                        }).AsEnumerable().Select(x => new ProductViewModel()
                        {
                            CateMetaTitle = x.MetaTitle,
                            CateName = x.Name,
                            CreatedDate = x.CreatedDate,
                            ID = x.ID,
                            Image = x.Images,
                            Name = x.Name,
                            MetaTitle = x.MetaTitle,
                            Price = x.Price
                        });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.Categories
                         on a.Category_id equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Image = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        /// <summary>
        /// list feature product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Products> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderBy(x => x.CreatedDate).Take(top).ToList();

        }

        public List<Products> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.Category_id == product.Category_id).ToList();
        }

        public Products ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        //public IEnumerable<Products> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<Products> model = db.Products.Include(p => p.Categories).Include(p => p.Colors).Include(p => p.Contries).Include(p => p.Materials).Include(p => p.Sizes);
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString));
        //    }
        //    return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        //}
    }
}
