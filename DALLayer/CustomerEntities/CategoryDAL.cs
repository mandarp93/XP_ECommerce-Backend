using DALLayer.DataRepository;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALLayer.CustomerEntities
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly DBModel dBModel;
        public CategoryDAL(DBModel dB)
        {
            dBModel = dB;
        }
        public List<Categories> GetCategoriesDAL()
        {
            return dBModel.Categories.ToList();
        }
    }
}
