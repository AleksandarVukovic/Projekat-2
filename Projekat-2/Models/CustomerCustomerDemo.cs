using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat_2.Models
{
    public partial class CustomerCustomerDemo
    {
        public CustomerCustomerDemo()
        {
        }

        public CustomerCustomerDemo(string customerId, string customerTypeId)
        {
            CustomerId = customerId;
            CustomerTypeId = customerTypeId;
        }

        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
