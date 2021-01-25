using Projekat_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Service
{
    public class CustomerDemographicService
    {
        internal void create(CustomerDemographic entity, NorthwindContext context)
        {
            string id = createId();
            entity.CustomerTypeId = id;
            context.Add(entity);
            context.SaveChangesAsync();
        }

        private static string createId()
        {
            string guid = Guid.NewGuid().ToString();
            string id = guid.Substring(0, 9);
            return id;
        }

        internal void batchCreate(List<CustomerDemographic> entities, Customer customer, NorthwindContext context)
        {
                entities.ForEach(x => x.CustomerTypeId = createId());
                List<CustomerCustomerDemo> lists = entities.Select(x => new CustomerCustomerDemo(customer.CustomerId, x.CustomerTypeId)).ToList();
                context.CustomerDemographics.AddRange(entities);
                context.CustomerCustomerDemos.AddRange(lists);
                context.SaveChanges();
           
        }
    }
}
