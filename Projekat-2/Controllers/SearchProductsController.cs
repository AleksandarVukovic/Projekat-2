using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekat_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_2.Controllers
{
    public class SearchProductsController : Controller
    {
        private readonly NorthwindContext _context;

        public SearchProductsController(NorthwindContext context)
        {
            _context = context;            
        }

        public IActionResult Index()
        {
            SearchProducts searchProducts = createDefaultModel();

            return View(searchProducts);
        }

        private SearchProducts createDefaultModel()
        {
            List<Category> categories = _context.Categories.ToList();
            List<Supplier> suppliers = _context.Suppliers.ToList();

            SearchProducts model = new SearchProducts();
            model.suppliers = suppliers.ToList().Select(x => new SelectListItem(x.CompanyName, x.SupplierId.ToString()));
            model.categories = categories.ToList().Select(x => new SelectListItem(x.CategoryName, x.CategoryId.ToString()));

            return model;
        }

        [HttpPost]
        public IActionResult SearchAct(SearchProducts model)
        {
            int categoryId = Int32.Parse(model.selectedCategoryId);
            int supplierId = Int32.Parse(model.selectedSupplierId);

            SearchProducts searchProducts = createDefaultModel();
            searchProducts.selectedCategoryId = model.selectedCategoryId;
            searchProducts.selectedSupplierId = model.selectedSupplierId;
           searchProducts.products = _context.Products
                .ToList()
                .Where(x => x.CategoryId == categoryId && x.SupplierId == supplierId)
                .Select(x => x);
            return View("~/Views/SearchProducts/Index.cshtml", searchProducts);
        }
    }
}
