using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerBL
    {
        List<Customers> GetCustomerDetails();
        Customers CustomerByName(string uname);
        Customers CustomerById(int cd);
        Customers Register(Customers formdata);
        Object LoginUser(LoginModel customermodel);
        Customers Update(Customers updateData);
        ResponseBL DeleteUser(int id);
    }
}
