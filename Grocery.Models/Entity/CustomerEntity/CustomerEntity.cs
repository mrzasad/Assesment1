
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Grocery.Models.Entity.CustomerEntity
{
    [Table("Customer")]
   public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
