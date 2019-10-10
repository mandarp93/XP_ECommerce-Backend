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
    public class CustomerDAL : ICutomerDAL
    {
        private readonly DBModel dBModel;
        public CustomerDAL(DBModel data)
        {
            dBModel = data;
        }
        public string AddCustomer(Customers customers)
        {
            if (customers != null)
            {
                Customers cust = new Customers();

                cust.FirstName = customers.FirstName;
                cust.LastName = customers.LastName;
                cust.EmailId = customers.EmailId;
                cust.Password = customers.Password;
                cust.MobileNo = customers.MobileNo;
                cust.RoleId = 2;
                dBModel.Customer.Add(cust);
                dBModel.SaveChanges();
            }
            return "success";
        }
        public List<Customers> RegisteredCustomer()
        {
            return dBModel.Customer.ToList();
        }

        public Object CheckUser(LoginModel model)
        {
            // Customers cust = new Customers();
            ResponseStatus status = new ResponseStatus();
            try
            {
                if (model != null)
                {
                    var usercheck = dBModel.Customer
                    .Where(x => x.EmailId == model.EmailId
                        && x.Password == model.Password).Select(u=> new { u.EmailId,u.RoleId}).FirstOrDefault();
                    if (usercheck != null)
                    {
                        status.Status = "success";
                        status.obj = usercheck;
                        return usercheck;
                    }
                    else
                    {
                        status.Status = "Invalid user";
                        return status;
                    }
                }
                else
                {
                    status.Status = "Inavlid";
                }
                return status;
            }
            catch (Exception ex)
            {
                status.Status = "Error";
                status.Error = ex;
            }
            status.Status = "Invalid";
            return status;
        }
        public Customers GetCustomerById(int id)
        {
            return dBModel.Customer.Where(x=> x.UserId == id).FirstOrDefault();
        }

        public Customers UpdateData(Customers udata)
        {
            Customers newcustomer = dBModel.Customer.Find(udata.UserId);
            newcustomer.FirstName = udata.FirstName;
            newcustomer.LastName = udata.LastName;
            newcustomer.MobileNo = udata.MobileNo;
            newcustomer.EmailId = udata.EmailId;
            newcustomer.Password = udata.Password;
            try
            {
                dBModel.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
            return newcustomer;
        }

        public ResponseStatus DeleteCustomer(int id)
        {
            ResponseStatus response = new ResponseStatus();
            var data = dBModel.Customer.Find(id);
            dBModel.Customer.Remove(data);
            dBModel.SaveChanges();
            response.Status = "successfully deleted";
            return response;
        }

        public Customers CutomerByNameDAl(string uname)
        {
            return dBModel.Customer.Where(x => x.EmailId == uname).FirstOrDefault();
        }
    }
}
