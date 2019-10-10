using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALLayer.CustomerEntities
{
    public class CartDAL : ICartDAL
    {
        private readonly DBModel model;
        public CartDAL(DBModel dBModel)
        {
            model = dBModel;
        }

        public List<Cart> showCartList()
        {
            return model.Cart.ToList();
        }

        public string AddToCart(CartView values)
        {
            Cart c = new Cart();
            var userkey = model.Customer.Where(x => x.EmailId == values.emailId).Select(u => u.UserId).SingleOrDefault();
            c.CustomerID = userkey;
            var stock = model.Product.Where(p => p.ProductId == values.productId).Select(q => q.Quantity).SingleOrDefault();
            c.PID = values.productId;
            // var duplicate = model.Cart.Where(cus => cus.CustomerID == userkey).Select(p => p.PID);
            var proexists = ProductExist(values.productId);
            if (proexists)
            {
                var tqty = model.Cart.Where(pd => pd.PID == values.productId).FirstOrDefault();
                tqty.Quantity = tqty.Quantity + values.quantity;
                tqty.TotalPrice = tqty.Quantity * tqty.UnitPrice;
            }
            else {
                var prodprice = model.Product.Where(p => p.ProductId == values.productId).Select(d => d.Price).SingleOrDefault();
                c.UnitPrice = prodprice;
                c.TotalPrice = c.UnitPrice * values.quantity;
                c.Quantity = values.quantity;
                model.Cart.Add(c);
            }
            model.SaveChanges();
            return "success";
        }

        public bool ProductExist(int id)
        {
            var pexists = model.Cart.Where(p => p.PID == id).FirstOrDefault();
            if (pexists != null)
            {
                return true;
            }
            else
                return false;
        }
        public Object GetCartByNameDAL(string uname)
        {
            Cart c = new Cart();
            var userkey = model.Customer.Where(x => x.EmailId == uname).Select(u => u.UserId).FirstOrDefault();
            c.CustomerID = userkey;
            //var data = model.Cart.Where(u => u.CustomerID == userkey).Select(cd => cd);
            var data = model.Cart.Join(model.Product,
                ct => ct.PID,
                p => p.ProductId,
                (ct, p) => new { p.ProductName, p.Image, ct.Quantity, ct.TotalPrice,
                    ct.UnitPrice, ct.CartId, ct.CustomerID});
            return data;
        }

        public void DeleteCartItem(int id)
        {
            var query = model.Cart.Where(c=> c.CartId == id).Select(s=> s).FirstOrDefault();
            model.Remove(query);
            model.SaveChanges();
        }
    }
}
