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
            string guid = Guid.NewGuid().ToString();
            string id = guid.Substring(0, 9);
            entity.CustomerTypeId = id;
            context.Add(entity);
            context.SaveChangesAsync();
        }
    }
}
