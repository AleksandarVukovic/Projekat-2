using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projekat_2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }



        public string CustomerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [MaxLength(30)]
        public string ContactName { get; set; }
        [MaxLength(30)]
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [MaxLength(15)]
        public string Region { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(15)]
        public string Country { get; set; }
        [MaxLength(24)]
        public string Phone { get; set; }
        [MaxLength(24)]
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
