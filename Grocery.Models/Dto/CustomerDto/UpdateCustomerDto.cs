using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grocery.Models.Dto.CustomerDto
{
    public class UpdateCustomerDto: CreateCustomerDto
    {
        [Key]
        public int CustomerId { get; set; }
        
    }

}
