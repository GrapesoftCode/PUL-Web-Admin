using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public class FoodViewModel
    {
        public string id { get; set; }
        //public string Time { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        //public string Subcategory { get; set; }
        public int Portion { get; set; }
        //public string Brand { get; set; }
        public double Grams { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public IFormFile Logo { get; set; }
        public string userId { get; set; }
        public string establishmentId { get; set; }
    }
}
