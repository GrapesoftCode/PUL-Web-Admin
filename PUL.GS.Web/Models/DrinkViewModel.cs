using Microsoft.AspNetCore.Http;
using PUL.GS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public class DrinkViewModel
    {
        public string id { get; set; }
        //public string Type { get; set; }
        public string Category { get; set; }
        //public string Subcategory { get; set; }
        public string Name { get; set; }
        public double Milliliters { get; set; }
        public double Grades { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        //public string Brand { get; set; }
        public bool Stock { get; set; }
        public IFormFile Logo { get; set; }
        public string userId { get; set; }
        public string establishmentId { get; set; }
    }
}
