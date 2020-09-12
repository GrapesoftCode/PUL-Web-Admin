using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.Models
{
    public class Drink
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
        public Logo Logo { get; set; }
        public string userId { get; set; }
        public string establishmentId { get; set; }
    }
}
