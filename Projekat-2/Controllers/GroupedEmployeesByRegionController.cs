using Microsoft.AspNetCore.Mvc;
using Projekat_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Controllers
{
    public class GroupedEmployeesByRegionController : Controller
    {
        private readonly NorthwindContext _context;

        public GroupedEmployeesByRegionController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = from asoc in _context.EmployeeTerritories
                         join ter in _context.Territories on asoc.TerritoryId equals ter.TerritoryId
                         join reg in _context.Regions on ter.RegionId equals reg.RegionId
                         group asoc.EmployeeId by new { reg.RegionId, reg.RegionDescription } into grouped
                         select new GroupedEmployeesByRegion(grouped.Key.RegionId, grouped.Key.RegionDescription, grouped.Count());
            
            return View(result.ToList());
        }
    }
}
