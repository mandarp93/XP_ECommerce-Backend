using BusinessLayer.Interfaces;
using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class OrderBL: IOrderBL
    {
        private readonly IOrderDAL orderDAL;
        public OrderBL(IOrderDAL odal)
        {
            orderDAL = odal;
        }

        public Object GetBuyDetailsBL(OrderModel orderModel)
        {
            if (orderModel != null)
            {
                return orderDAL.GetBuyDetailsDAL(orderModel);
            }
            else
                return false;
        }

        public List<Orders> GetOrderDetailsBL()
        {
            return orderDAL.GetOrderDetailsDAL();
        }

        public object GetOrdersByUser(string uname)
        {
            return orderDAL.GetOrdersByUserDAL(uname);
        }

        public Orders PostOrder(OrderView order)
        {
            return orderDAL.PostOrder(order);
        }
    }
}
