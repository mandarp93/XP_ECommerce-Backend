using BusinessLayer.Interfaces;
using DALLayer.DataRepository;
using DomainModels;
using DomainModels.SharedModels;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CustomerBL: ICustomerBL
    {
        private readonly ICutomerDAL iuser;
        public CustomerBL(ICutomerDAL userRegister)
        {
            iuser = userRegister;
        }

        public List<Customers> GetCustomerDetails()
        {
            return iuser.RegisteredCustomer();
        }

        public Object LoginUser(LoginModel customermodel)
        {
            ResponseBL response = new ResponseBL();
            if (customermodel != null)
            {
                var user = iuser.CheckUser(customermodel);
                if (user != null)
                {
                    response.Status = "success";
                    response.obj = user;
                    return user;
                }
                else
                    response.Status = "Invalid User";
            }
            else
                response.Status = "Error";
            return response;
        }

        public Customers Register(Customers data)
        {
            if(data != null)
            {

                iuser.AddCustomer(data);
            }
            return null;
        }

        public Customers CustomerById(int cd)
        {
            return iuser.GetCustomerById(cd);
        }

        public Customers Update(Customers updateData)
        {
            return iuser.UpdateData(updateData);
        }

        public ResponseBL DeleteUser(int id)
        {
            ResponseBL status = new ResponseBL();
            iuser.DeleteCustomer(id);
            status.Status = "success";
            return status;
        }

        public Customers CustomerByName(string uname)
        {
            return iuser.CutomerByNameDAl(uname);
        }
    }
}
