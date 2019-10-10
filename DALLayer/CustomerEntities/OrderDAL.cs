using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALLayer.CustomerEntities
{
    public class OrderDAL : IOrderDAL
    {
        private readonly DBModel model;
        public OrderDAL(DBModel dBModel)
        {
            model = dBModel;
        }

        public Object GetBuyDetailsDAL(OrderModel orderModel)
        {
            
            if (orderModel != null)
            {
                Cart c = new Cart();
                var userdetails = model.Customer.Where(x => x.EmailId == orderModel.Email)
                    .Select(u => u).FirstOrDefault();
                var productdetails = model.Product.Where(x => x.ProductId == orderModel.ProdId)
                    .Select(p => p).FirstOrDefault();
                return productdetails;
            }
            else
            return false;
        }

        public List<Orders> GetOrderDetailsDAL()
        {
            //OrderView orderView = new OrderView();
            var query = model.Order.ToList();
            if (query != null)
            {
                return query;
            }
            else
            return null;
        }
        
        public object GetOrdersByUserDAL(string uname)
        {
            //List<OrderModel> ord = new List<OrderModel>();
            OrderModel ord = new OrderModel();
            var userkey = model.Customer.Where(u=> u.EmailId==uname).Select(i=> i.UserId).SingleOrDefault();
            var pkeys = model.Order.Where(o => o.CustomerId == userkey).Select(orders => orders.ProductID);
            //foreach (int pid in pkey)
            //{
            //    var product = model.Product.Where(p => p.ProductId == pkey.FirstOrDefault()).Select(pr => pr.ProductName).FirstOrDefault();
            //    ord.Product = product;
            //    var total = model.Order.Where(o => o.ProductID == pkey.FirstOrDefault()).Select(tp => tp.TotalPrice);
            //    ord.TotalPrice = Convert.ToDouble(total);
            //    var Qty = model.Order.Where(o => o.Quantity == pkey.FirstOrDefault()).Select(qt => qt.Quantity);
            //    ord.Quantity = Convert.ToInt32(Qty);
            //}
            // ord.Address = model.Order.Where(o => o.CustomerId == userkey).Select(ad => ad.Address).FirstOrDefault();
            var details = from o in model.Order
                          where o.CustomerId == userkey
                          join p in model.Product on o.ProductID equals p.ProductId
                          select new
                          {
                              o.OrderDate,
                              p.ProductName,
                              o.Quantity,
                              o.TotalPrice,
                              p.Image
                          };
            return details.ToList();
        }

        public Orders PostOrder(OrderView orderView)
        {
            Orders orders = new Orders();
            var userkey= model.Customer.Where(c=> c.EmailId == orderView.Email).Select(u=>u.UserId).FirstOrDefault();
            orders.CustomerId = userkey;
            orders.ProductID = model.Cart.Where(c => c.CustomerID == userkey).Select(u => u.PID).FirstOrDefault();
            var qty = model.Cart.Where(c => c.CustomerID == userkey).Select(u => u.Quantity).FirstOrDefault();
            orders.Quantity = qty;
            orders.OrderDate = DateTime.Now;
            orders.Price = model.Cart.Where(c => c.CustomerID == userkey).Select(u => u.UnitPrice).FirstOrDefault();
            orders.TotalPrice = model.Cart.Where(c => c.CustomerID == userkey).Select(u => u.TotalPrice).FirstOrDefault();
            orders.Address = orderView.City + ", " + orderView.Landmark + ", " +  orderView.State + ", " 
                + orderView.PinCode.ToString();
            orders.Status = "Placed";
            model.Order.Add(orders);
            model.SaveChanges();
            return orders;
        }
    }
}
 