﻿using Microsoft.AspNetCore.Http;
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
            }
            else if (aaa.createCustomers == 2)
            {
                aaa.multipleDemographics.customersInDatabase = _context.Customers.Select(x => new SelectListItem(x.CompanyName, x.CustomerId)).ToList();
            }

            return View(nameof(Index), aaa);
        }

        [HttpPost]
        public IActionResult SelectDemographic(MultipleInputCustomersAndDemographics model)
        {
            string selectedDemographicId = model.multipleCustomers.selectedDemographicId;
            if (selectedDemographicId != null)
            {
                model.multipleCustomers.demographicsInDatabase.Find(x => x.Value.Equals(selectedDemographicId)).Selected = true;
            }

            return View(nameof(Index), model);
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
            } else
            {
                aaa.multipleCustomers.newCustomer = customer;
            }
            return View(nameof(Index), aaa);
        }

        [HttpPost]
        public IActionResult BatchCreateCustomers(MultipleInputCustomersAndDemographics model)
        {

            if (ModelState.IsValid)
            {
                string selectedDemographicId = model.multipleCustomers.selectedDemographicId;
                CustomerDemographic customerDemographic = _context.CustomerDemographics.Find(selectedDemographicId);
                List<Customer> newCustomers = model.multipleCustomers.newCustomers;
                customerService.batchCreate(newCustomers, customerDemographic, _context);

                model.multipleCustomers = new MultipleCustomers();
                model.createCustomers = 0;
                return View(nameof(Index), model);
            }
             return View(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult SelectCustomer(MultipleInputCustomersAndDemographics model)
        {
            string selectedCustomerId = model.multipleDemographics.selectedCustomerId;
            if (selectedCustomerId != null)
            {
                model.multipleDemographics.customersInDatabase.Find(x => x.Value.Equals(selectedCustomerId)).Selected = true;
            }
            return View(nameof(Index), model);
        }

        //GET
        public IActionResult CreateDemographic(MultipleInputCustomersAndDemographics aaa)
        {

            aaa.multipleDemographics.newDemographic = new CustomerDemographic();
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
            else
            {
                aaa.multipleDemographics.newDemographic = customerDemographic;
            }
            return View(nameof(Index), aaa);
        }

        [HttpPost]
        public IActionResult BatchCreateDemographics(MultipleInputCustomersAndDemographics model)
        {

            if (ModelState.IsValid)
            {
                string selectedCustomerId = model.multipleDemographics.selectedCustomerId;
                Customer customer = _context.Customers.Find(selectedCustomerId);
                List<CustomerDemographic> newDemographics = model.multipleDemographics.newDemographics;
                customerDemographicService.batchCreate(newDemographics, customer, _context);

                model.multipleDemographics = new MultipleDemographics();
                model.createCustomers = 0;
                return View(nameof(Index), model);
            }
            return View(model);
        }

    }
}
