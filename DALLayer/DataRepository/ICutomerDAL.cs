using DALLayer.CustomerEntities;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALLayer.DataRepository
{
    public interface ICutomerDAL
    {
        List<Customers> RegisteredCustomer();
        Customers CutomerByNameDAl(string uname);
        Customers GetCustomerById(int id);
        string AddCustomer(Customers fields);
        Object CheckUser(LoginModel customerView);
        Customers UpdateData(Customers udata);
        ResponseStatus DeleteCustomer(int id);
        
    }
}
