using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; } 
        public string Explanation { get; set; }
        public string TrackingCode { get; set; }
        public string Employee { get; set; }
        public string Buyer { get; set; }
        public DateTime Date { get; set; }
    }
}