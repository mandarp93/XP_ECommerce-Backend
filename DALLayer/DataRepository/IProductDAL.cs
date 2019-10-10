using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALLayer.DataRepository
{
    public interface IProductDAL
    {
        List<Products> showProductList();
        Products ShowProductById(int productid);
        string AddProducts(Products values);
        ResponseStatus UpdateProductDAL(Products values);
        List<Products> ProductByCategoryDAL(int id);
        void DeleteProductDAL(int id);
    }
}
