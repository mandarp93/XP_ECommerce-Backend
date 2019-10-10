using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALLayer.DataRepository
{
    public interface ICategoryDAL
    {
        List<Categories> GetCategoriesDAL();
    }
}
