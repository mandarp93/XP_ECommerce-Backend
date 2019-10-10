using BusinessLayer.Interfaces;
using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CartBL: ICartBL
    {
        private readonly ICartDAL cart;
        public CartBL(ICartDAL cartBL)
        {
            cart = cartBL;
        }

        public ResponseBL AddToCart(CartView model)
        {
            ResponseBL response = new ResponseBL();
            if (model != null)
            {
                //if (model.quantity == 0)
                //{
                //    model.quantity = model.quantity + 1;
                //}
                cart.AddToCart(model);
                response.Status = "success";
            }
            else
                response.Status = "error";
            return response;
        }

        public void DeleteCartItem(int id)
        {
            cart.DeleteCartItem(id);
        }

        public Object GetCartByName(string uname)
        {
            var cartdetails=cart.GetCartByNameDAL(uname);
            return cartdetails;
        }

        public List<Cart> GetCartDetails()
        {
            return cart.showCartList();
        }

    }
}
