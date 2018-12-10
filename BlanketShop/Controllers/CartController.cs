using BlanketShop.Models;
using Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BlanketShop.Common;

namespace BlanketShop.Controllers
{
    public class CartController : Controller
    {
        //  private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CommonConstant.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CommonConstant.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cartItem 
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //gán vào session
                Session[CommonConstant.CartSession] = list;

            }
            else
            {
                //tạo mới đối tượng cartItem 
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                //gán vào session
                Session[CommonConstant.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string mobile, string address)
        {
            if (Session[CommonConstant.USER_SESSION] != null)
            {
                var user = Session[CommonConstant.USER_SESSION] as UserLogin;

                string shipName = user.Name;
                string email = user.Email;

                var order = new Orders();
                order.CreatedDate = DateTime.Now;
                order.ShipAddress = address;
                order.ShipMobile = mobile;
                order.ShipName = shipName;
                order.ShipEmail = email;
                var contentOrder = "";
                decimal sumTotalProduct = 0;
                try
                {
                    var id = new OrderDao().Insert(order);
                    var cart = (List<CartItem>)Session[CommonConstant.CartSession];
                    var detailDao = new OrderDetailDao();
                    decimal total = 0;
                    foreach (var item in cart)
                    {
                        sumTotalProduct += item.Product.Price.GetValueOrDefault(0) * item.Quantity;
                        var orderDetail = new OrderDetails();
                        orderDetail.ProductID = item.Product.ID;
                        orderDetail.OrderID = id;
                        orderDetail.Price = item.Product.Price;
                        orderDetail.Quantity = item.Quantity;
                        detailDao.Insert(orderDetail);
                        total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);

                        contentOrder += "<tr>";
                        contentOrder += "<td style=\"border: 1px solid #ccc;padding-left: 5px;\">" + item.Product.Name + "</td>";
                        contentOrder += "<td style=\"border: 1px solid #ccc;padding-left: 5px;\">" + item.Quantity + "</td>";
                        contentOrder += "<td style=\"border: 1px solid #ccc;padding-left: 5px;\">" + item.Product.Price.GetValueOrDefault(0).ToString("N0") + " </td>";
                        contentOrder += "<td style=\"border: 1px solid #ccc;padding-left: 5px;\">" + ((item.Product.Price.GetValueOrDefault(0) * item.Quantity).ToString("N0")) + "</td>";
                        contentOrder += "</tr>";
                    }
                    contentOrder += "<tr><td></td><td></td><td></td><td style=\"border: 1px solid #ccc;padding-left: 5px;\"><b>Tổng tiền: " + sumTotalProduct.ToString("N0") + "đ</b></td></tr>";

                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/neworder.html"));


                    content = content.Replace("{{CustomerName}}", shipName);
                    content = content.Replace("{{Phone}}", mobile);
                    content = content.Replace("{{Email}}", email);
                    content = content.Replace("{{Address}}", address);
                    content = content.Replace("{{Total}}", total.ToString("N0"));
                    content = content.Replace("{{ContentOrder}}", contentOrder);

                    //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    //new MailHelper().SendMail(email, "Đơn hàng mới từ BlanketShop", content);
                    //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ BlanketShop", content);

                    //Xoa gio hang
                    Session[CommonConstant.CartSession] = null;
                }
                catch (Exception ex)
                {
                    //ghi log
                    return Redirect("/loi-thanh-toan");
                }
                return Redirect("/hoan-thanh");
            }
            else
            {
                return RedirectToAction("Login", "User", new { ReturnUrl = "thanh-toan" });
            }
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}