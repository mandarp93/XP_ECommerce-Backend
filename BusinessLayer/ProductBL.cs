using BusinessLayer.Interfaces;
using DALLayer;
using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class ProductBL : IProductBL
    {
        private IProductDAL details;
        public ProductBL(IProductDAL idetails)
        {
            details = idetails;
        }

        public ResponseBL AddProductBL(Products values)
        {
            ResponseBL status = new ResponseBL();
            if (values != null)
            {
                details.AddProducts(values);
                status.Status = "success";
            }
            else
                status.Status = "error";
            return status;
        }

        public void DeleteProduct(int id)
        {
            details.DeleteProductDAL(id);
        }

        public Products GetById(int pid)
        {
            return details.ShowProductById(pid);
        }

        public List<Products> GetProduct()
        {
            return details.showProductList();
        }

        public List<Products> ProductByCategoryBL(int id)
        {
            var data = details.ProductByCategoryDAL(id);
            return data;
        }

        public ResponseBL UpdateProduct(Products values)
        {
            ResponseBL status = new ResponseBL();
            if (values != null)
            {
                details.UpdateProductDAL(values);
                status.Status = "success";
            }
            else
                status.Status = "error";
            return status;
        }
    }
}
