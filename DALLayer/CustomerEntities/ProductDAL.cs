using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALLayer.CustomerEntities
{
    public class ProductDAL : IProductDAL
    {
        private DBModel model;
        public ProductDAL(DBModel dBModel)
        {
            model = dBModel;
        }

        public string AddProducts(Products values)
        {
            if (values != null)
            {
                var query = model.Product.Add(values);
                model.SaveChanges();
            }
            return "success";
        }

        public void DeleteProductDAL(int id)
        {
            var product = model.Product.Where(p => p.ProductId == id).FirstOrDefault();
            model.Product.Remove(product);
            model.SaveChanges();
        }

        public List<Products> ProductByCategoryDAL(int id)
        {
            var products = model.Product.Where(p=> p.CategId == id).Select(a=> a).ToList();
            return products;
        }

        public Products ShowProductById(int productid)
        {
            return model.Product.Where(x=> x.ProductId == productid).FirstOrDefault();  //Linq always return a sequence so Single or First is mandatory
        }

        public List<Products> showProductList()
        {
            return model.Product.ToList();
        }

        public ResponseStatus UpdateProductDAL(Products values)
        {
            ResponseStatus status = new ResponseStatus();
            if (values != null)
            {
                Products products = new Products();
                products.CategId = values.CategId;
                products.Details = values.Details;
                products.Price = values.Price;
                products.ProductId = values.ProductId;
                products.ProductName = values.ProductName;
                products.Quantity = values.Quantity;
                products.Image = values.Image;
                model.SaveChanges();
                status.Status = "success";
                return status;
            }
            else
            {
                status.Status = "Error";
            }
            return status;

        }
    }
}
