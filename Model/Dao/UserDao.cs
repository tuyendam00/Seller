using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;

namespace Model.Dao
{
    public class UserDao
    {
        BlanketShopDbContext db = null;


        public UserDao()
        {
            db = new BlanketShopDbContext();
        }
        public long Insert(User entity)
        {
            
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public long InsertForFacebook(User entity)
        {
            var user = db.User.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.User.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }

        }


        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Password = entity.Password;
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;



                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }


        public User ViewDetail(int id)
        {
            return db.User.Find(id);// nếu khóa chính là kiểu int
        }


        public int Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }

            }
        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }


        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckUserName(string userName)
        {
            return db.User.Count(x => x.UserName == userName) > 0;
        }


        public bool CheckEmail(string email)
        {
            return db.User.Count(x => x.Email == email) > 0;
        }
    }
}
