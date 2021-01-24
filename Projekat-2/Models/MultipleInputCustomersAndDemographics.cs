using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Models
{
    public class MultipleInputCustomersAndDemographics
    {
        public Customer newCustomer { get; set; }
        public List<Customer> newCustomers { get; set; }
        public List<Customer> customersInDatabase { get; set; }

        public CustomerDemographic newDemographic { get; set; }
        public List<CustomerDemographic> newDemographics { get; set; }
        public List<CustomerDemographic> demographicsInDatabase { get; set; }

    }
}
