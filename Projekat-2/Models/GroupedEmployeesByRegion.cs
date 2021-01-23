using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Models
{
    public class GroupedEmployeesByRegion
    {

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        public int employeesNumber { get; set; }

        public GroupedEmployeesByRegion(int regionId, string regionDescription, int employeesNumber)
        {
            RegionId = regionId;
            RegionDescription = regionDescription;
            this.employeesNumber = employeesNumber;
        }
    }
}
