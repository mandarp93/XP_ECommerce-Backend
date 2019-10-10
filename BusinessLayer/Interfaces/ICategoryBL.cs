using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICategoryBL
    {
        List<Categories> GetCategories();
    }
}
