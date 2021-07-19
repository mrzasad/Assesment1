using Grocery.Models.Dto.CustomerDto;
using Grocery.Models.Dto.MessageStatusDto;
using Grocery.Models.Entity.CustomerEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Service.CustomerServices
{
   public interface ICustomerService
    {
        public CustomerEntity Get(int id);
        public List<CustomerEntity> Get();

        public MessageStatusDto create(CreateCustomerDto dto);
        public MessageStatusDto update(UpdateCustomerDto dto);
    }
}
