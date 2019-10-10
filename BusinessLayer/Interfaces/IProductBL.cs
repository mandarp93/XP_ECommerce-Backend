using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IProductBL
    {
        List<Products> GetProduct();
        Products GetById(int pid);
        ResponseBL AddProductBL(Products values);
        ResponseBL UpdateProduct(Products values);
        List<Products> ProductByCategoryBL(int id);
        void DeleteProduct(int id);
    }
}
