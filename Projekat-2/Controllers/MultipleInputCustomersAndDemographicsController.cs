using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekat_2.Models;
using Projekat_2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Controllers
{
    public class MultipleInputCustomersAndDemographicsController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly CustomerService customerService;
        private readonly CustomerDemographicService customerDemographicService;

        public MultipleInputCustomersAndDemographicsController(NorthwindContext context)
        {
            _context = context;
            customerService = new CustomerService();
            customerDemographicService = new CustomerDemographicService();
        }

        // GET: MultipleInputCustomersAndDemographicsController
        public ActionResult Index()
        {
            MultipleInputCustomersAndDemographics model = new MultipleInputCustomersAndDemographics();
            return base.View(model);
        }

        public IActionResult ChooseView(MultipleInputCustomersAndDemographics aaa)
        {
            if (aaa.createCustomers == 1)
            {
                aaa.multipleCustomers.demographicsInDatabase = _context.CustomerDemographics.Select(x => new SelectListItem(x.CustomerDesc, x.CustomerTypeId.ToString())).ToList(); ;
            } else if(aaa.createCustomers == 2)
            {
                aaa.multipleDemographics.customersInDatabase = _context.Customers.Select(x => new SelectListItem(x.CompanyName, x.CustomerId)).ToList();
            }

            return View(nameof(Index), aaa);
        }

        //GET
        public IActionResult CreateCustomer(MultipleInputCustomersAndDemographics aaa)
        {

            aaa.multipleCustomers.newCustomer = new Customer();
            return View(nameof(Index), aaa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer([Bind("CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer, MultipleInputCustomersAndDemographics aaa)
        {
            if (ModelState.IsValid)
            {
                aaa.multipleCustomers.newCustomers.Add(customer);
                aaa.multipleCustomers.newCustomer = null;
                return View(nameof(Index), aaa);
            }
            return View(customer);
        }

        //GET
        public IActionResult CreateDemographic(MultipleInputCustomersAndDemographics aaa)
        {

            aaa.multipleDemographics.newDemographic= new CustomerDemographic();
            return View(nameof(Index), aaa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDemographic([Bind("CustomerDesc")] CustomerDemographic customerDemographic, MultipleInputCustomersAndDemographics aaa)
        {
            if (ModelState.IsValid)
            {
                aaa.multipleDemographics.newDemographics.Add(customerDemographic);
                aaa.multipleDemographics.newDemographic = null;
                return View(nameof(Index), aaa);
            }
            return View(customerDemographic);
        }

    }
}
