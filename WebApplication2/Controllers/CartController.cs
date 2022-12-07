using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();

        public CartModel GetCart()
        {
            CartModel cart = Session["Cart"] as CartModel;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new CartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCard(int id )
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var pro = objQUANLITHOITRANGEntities.products.SingleOrDefault(s => s.id == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCard", "Cart");
        }
        public ActionResult ShowToCard()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCard", "Cart");
            CartModel cart = Session["Cart"] as CartModel;
            return View(cart);
        }

        public ActionResult UpdateQuantityCard(FormCollection form)
        {
            CartModel cart = Session["Cart"] as CartModel;
            int id_pro =int.Parse( form["id_product"]);
            int quantity = int.Parse(form["quantity"]);
            cart.Update_quantity(id_pro, quantity);
            TempData["error1"] = "Số lượng không hợp lệ";
            return RedirectToAction("ShowToCard", "Cart");
        }

        public ActionResult RemoveCard(int id)
        {
            CartModel cart = Session["Cart"] as CartModel;
            cart.Remove_Card(id);
            return RedirectToAction("ShowToCard", "Cart");
        }
        public ActionResult OrderCard(string id)
        {
            //Them Don hang
            transaction ddh = new transaction();
            Account kh = (Account)Session["user"];
            List<CartItem> gh = getcart();
            ddh.id = kh.id;
            ddh.user_id = kh.id;
            ddh.dateorder = DateTime.Now;
            ddh.dateship = DateTime.Now;
            ddh.status = false;
            objQUANLITHOITRANGEntities.transactions.Add(ddh);
            objQUANLITHOITRANGEntities.SaveChanges();
            foreach (var item in gh)
            {
                order ctdh = new order();
                ctdh.id = ddh.id;
                ctdh.product_id = item.product.id;
                ctdh.qty = item.quantity;
                ctdh.amount = (int)item.product.price;
                objQUANLITHOITRANGEntities.orders.Add(ctdh);
                objQUANLITHOITRANGEntities.SaveChanges();
                Session["Cart"] = null;
            }
            return RedirectToAction("AcceptOrder", "Cart");
        }
        public ActionResult AcceptOrder()
        {
            return View();
        }
        public List<CartItem> getcart()
        {
            List<CartItem> lstCart = Session["CartItem"] as List<CartItem>;
            if (lstCart == null)
            {
                lstCart = new List<CartItem>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
    }
}
