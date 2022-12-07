 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Models
{
    public class CartItem
    {
        public product product { get; set; }
        public int quantity { get; set; }
    }

    public class CartModel
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add (product _pro , int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.product.id == _pro.id);
            if (item == null)
            {
                items.Add(new CartItem 
                {
                    product = _pro ,
                    quantity = _quantity
                });
            }
            else
            {
                item.quantity += _quantity;
            }
        }
        public void Update_quantity(int id , int quantity)
        {
            var item = items.Find(s => s.product.id == id);
            if(item != null && quantity > 0)
            {
                item.quantity = quantity;
            }  
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s.product.price * s.quantity);
            return (double)total;
        }

        public void Remove_Card(int id)
        {
            items.RemoveAll(s => s.product.id == id);
        }
    }
}