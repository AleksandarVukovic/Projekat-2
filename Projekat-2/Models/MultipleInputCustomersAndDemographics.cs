using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Models
{
    public class MultipleInputCustomersAndDemographics
    {
        public MultipleInputCustomersAndDemographics()
        {
            multipleCustomers = new MultipleCustomers();
            multipleDemographics = new MultipleDemographics();
        }

        public int createCustomers { get; set; }

        
      public MultipleCustomers multipleCustomers { get; set; }

        public MultipleDemographics multipleDemographics { get; set; }
    }
    
    public class MultipleCustomers
    {
        public MultipleCustomers()
        {
            newCustomers = new List<Customer>();
        }

        public string selectedDemographicId { get; set; }
        public List<SelectListItem> demographicsInDatabase { get; set; }

        public Customer newCustomer{ get; set; }
        public List<Customer> newCustomers { get; set; }
    }

    public class MultipleDemographics
    {
        public MultipleDemographics()
        {
            newDemographics = new List<CustomerDemographic>();
        }

        public string selectedCustomerId;
        public List<SelectListItem> customersInDatabase { get; set; }

        public CustomerDemographic newDemographic { get; set; }
        public List<CustomerDemographic> newDemographics { get; set; }
    }
}
