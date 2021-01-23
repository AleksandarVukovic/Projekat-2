using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Projekat_2.Models
{
    public class SearchProducts
    {
        public SearchProducts()
        {
            this.products = new List<Product>();
        }

        public String selectedSupplierId { get; set; }
        public  IEnumerable<SelectListItem> suppliers { get; set; }

        public String selectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> categories{ get; set; }

        public IEnumerable<Product> products { get; set; }

    }
}
