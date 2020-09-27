using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.Models
{
    public class Menu
    {
        public string id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Logo Logo { get; set; }
        public string userId { get; set; }
        public string establishmentId { get; set; }
        public int Index { get; set; }
        public string Detail
        {

            get
            {
                return string.Format("{0} {1}", Quantity, Name);
            }
        }

        public string DetailPrice
        {

            get
            {
                return string.Format("{0:C2}", Quantity * Price);
            }
        }
        public DateTime RegisterDate { get; set; }
        //public Status Status { get; set; }
        //public CollectionType CollectionType { get; set; }
    }
}
