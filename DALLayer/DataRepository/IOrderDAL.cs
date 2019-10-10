using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALLayer.DataRepository
{
    public interface IOrderDAL
    {
        List<Orders> GetOrderDetailsDAL();
        Object GetBuyDetailsDAL(OrderModel orderModel);
        Orders PostOrder(OrderView orderView);
        object GetOrdersByUserDAL(string uname);
    }
}
