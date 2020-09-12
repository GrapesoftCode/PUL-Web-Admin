using Microsoft.AspNetCore.Http;
using PUL.GS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public class EstablishmentViewModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Rfc { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Cover { get; set; }
        public string MusicalGenre { get; set; }
        public string CostLevel { get; set; }
        public string Type { get; set; }
        public string userId { get; set; }
        public AddressViewModel Address { get; set; }
        public AddressViewModel FiscalAddress { get; set; }
        public IFormFile Logo { get; set; }
        public List<IFormFile> Inside { get; set; }
        public List<IFormFile> Outside { get; set; }
        //public IFormFile InsideThree { get; set; }
        //public IFormFile OutsideOne { get; set; }
        //public IFormFile OutsideTwo { get; set; }
        //public IFormFile OutsideThree { get; set; }
    }
}
