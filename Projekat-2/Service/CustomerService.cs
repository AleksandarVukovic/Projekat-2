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
            string guid = Guid.NewGuid().ToString();
            string id = guid.Substring(0, 4);
            entity.CustomerId = id;
            context.Add(entity);
            context.SaveChangesAsync();
        }

    }
}
