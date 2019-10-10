using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICartBL
    {
        List<Cart> GetCartDetails();
        ResponseBL AddToCart(CartView model);
        Object GetCartByName(string uname);
        void DeleteCartItem(int id);
    }
}
