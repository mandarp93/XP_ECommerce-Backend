using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALLayer.DataRepository
{
    public interface ICartDAL
    {
        List<Cart> showCartList();
        string AddToCart(CartView values);
        Object GetCartByNameDAL(string uname);
        void DeleteCartItem(int id);
    }
}
