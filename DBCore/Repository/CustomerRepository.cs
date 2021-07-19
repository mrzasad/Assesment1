using Grocery.Models.Entity.CustomerEntity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {


        public virtual bool Add(CustomerEntity entity)
        {
            List<CustomerEntity> list = new List<CustomerEntity>();
            if (File.Exists("db.json"))
            {
                string json = File.ReadAllText("db.json");
                list = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                entity.CustomerId = list.Count + 1;
                list.Add(entity);
            }
            else
            {
                entity.CustomerId = 1;
                list.Add(entity);
            }
            File.WriteAllText("db.json", JsonConvert.SerializeObject(list));
            return true;
        }

        public CustomerEntity Get(int id)
        {
            List<CustomerEntity> list = new List<CustomerEntity>();
            if (File.Exists("db.json"))
            {
                string json = File.ReadAllText("db.json");
                list = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                return list.Find(x => x.CustomerId == id);
            }
            return null;
        }

        public List<CustomerEntity> GetAll()
        {
            List<CustomerEntity> list = new List<CustomerEntity>();
            if (File.Exists("db.json"))
            {
                string json = File.ReadAllText("db.json");
                list = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                return list;
            }
            return null;
        }

        public bool Update(CustomerEntity entity)
        {
            List<CustomerEntity> list = new List<CustomerEntity>();
            if (File.Exists("db.json"))
            {
                string json = File.ReadAllText("db.json");
                list = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                var customer = list.Find(x => x.CustomerId == entity.CustomerId);
                if (customer == null)
                    return false;
                int index = list.IndexOf(customer);
                list[index] = entity;
                File.WriteAllText("db.json", JsonConvert.SerializeObject(list));
                return true;
            }
            return false;
        }
    }
}
