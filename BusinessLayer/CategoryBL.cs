using BusinessLayer.Interfaces;
using DALLayer.DataRepository;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CategoryBL : ICategoryBL
    {
        private readonly ICategoryDAL categoryDAL;
        public CategoryBL(ICategoryDAL catDAL)
        {
            categoryDAL = catDAL;
        }
        public List<Categories> GetCategories()
        {
            return categoryDAL.GetCategoriesDAL();
        }
    }
}
