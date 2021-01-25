using Projekat_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Service
{
    public class CustomerService
    {

        public void create(Customer entity, NorthwindContext context)
        {
            string id = createId();
            entity.CustomerId = id;
            context.Add(entity);
            context.SaveChanges();
        }

        private static string createId()
        {
            string guid = Guid.NewGuid().ToString();
            string id = guid.Substring(0, 4);
            return id;
        }

        public void batchCreate(List<Customer> entities, CustomerDemographic demographic, NorthwindContext context)
        {
            entities.ForEach(x => x.CustomerId = createId());
            List<CustomerCustomerDemo> lists = entities.Select(x => new CustomerCustomerDemo(x.CustomerId, demographic.CustomerTypeId)).ToList();
            context.Customers.AddRange(entities);
            context.CustomerCustomerDemos.AddRange(lists);
            context.SaveChanges();
        }

    }
}
