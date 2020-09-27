using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.Models
{
    public class Book
    {
        public string id { get; set; }
        public string Token { get; set; }
        public string Qr { get; set; }
        public Table Table { get; set; }
        public int Persons { get; set; }
        public string Hour { get; set; }
        public string Date { get; set; }
        public List<Menu> Menus { get; set; }
        public double TotalMinimumConsumption { get; set; }
        public int TipPercent { get; set; }
        public double SubTotal { get; set; }
        public double Commission { get; set; }
        public double PerPerson { get; set; }
        public double Total { get; set; }
        public int BookStatus { get; set; }
        public string userId { get; set; }
        public string establishmentId { get; set; }
        public string PlayerId { get; set; }


        public string LocationTable 
        {
            get
            {
                return Table != null ? string.Format("Ubicación de mesa: {0}", Table.Location, Table.MinimumConsumption) : "";
            }
                
        }

        public string PersonNumbers { 
            get {
                return Persons >0 ? string.Format("Número de personas: {0}", Persons) : "";
            }
        }

        public string ConsumptionText {
            get {
                return Table != null ? string.Format("Consúmo mínimo por persona: {0}", Table.MinimumConsumption) : "";
            }
        }

        public string DateHour
        {

            get
            {
                return string.Format("{0} / {1}", Date, Hour);
            }
        }

        public string BookStateText
        {

            get
            {
                return BookStatus == 1 ? "Pendiente" :
                       BookStatus == 2 ? "Aceptada" :
                       BookStatus == 3 ? "En proceso" :
                       "Terminada";
            }
        }

        public string FullName { get; set; }


        public string TotalText {
            get {
                return Total > 0 ? string.Format("{0:c2}", Total) : ""; 
            }
        }
    }
}
