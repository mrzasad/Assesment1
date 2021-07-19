using Grocery.Models.Entity.CustomerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBCore.Repository
{
   public interface ICustomerRepository
    {
        bool Add(CustomerEntity entity);
        bool Update(CustomerEntity entity);
        CustomerEntity Get(int id);
        List<CustomerEntity> GetAll();
       
    }
}
