using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public class AddressViewModel
    {
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Municipality { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string OutdoorNumber { get; set; }
        public string InteriorNumber { get; set; }
    }
}
