using DBCore.Repository;
using Grocery.Models.Dto.CustomerDto;
using Grocery.Models.Dto.MessageStatusDto;
using Grocery.Models.Entity.CustomerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocery.Service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepositorysitory)
        {
            _customerRepository = customerRepositorysitory;
        }

        public CustomerEntity Get(int id)
        {
            var data = _customerRepository.Get(id);
            return data;
        }
        
        public List<CustomerEntity> Get()
        {
            var data = _customerRepository.GetAll();
            return data;
        }
        public MessageStatusDto create(CreateCustomerDto dto)
        {
            MessageStatusDto statusDto = new MessageStatusDto();
            CustomerEntity enObj = new CustomerEntity
            {
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                CustomerPhone = dto.CustomerPhone,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _customerRepository.Add(enObj);

            statusDto.Message = "Saved";
            return statusDto;
        }



        public MessageStatusDto update(UpdateCustomerDto dto)
        {

            var Customerdata = _customerRepository.Get(dto.CustomerId);
            if (Customerdata != null)
            {
                MessageStatusDto statusDto = new MessageStatusDto();
                Customerdata.CustomerName = dto.CustomerName;
                Customerdata.CustomerEmail = dto.CustomerEmail;
                Customerdata.CustomerPhone = dto.CustomerPhone;
                Customerdata.ModifiedDate = DateTime.Now;
                _customerRepository.Update(Customerdata);
                statusDto.Message = "Updated";
                return statusDto;
            }
            return null;
        }
    }
}
