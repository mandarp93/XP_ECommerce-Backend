using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        List<Orders> GetOrderDetailsBL();
        Object GetBuyDetailsBL(OrderModel orderModel);
        Orders PostOrder(OrderView order);
        object GetOrdersByUser(string uname);
    }
}
