using Microsoft.AspNetCore.Http;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public class PromotionViewModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public IFormFile Logo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string establishmentId { get; set; }
        public string userId { get; set; }
    }
}
