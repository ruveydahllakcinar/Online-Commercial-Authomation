using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class SaleMove
    {
        [Key]
        public int SalesId { get; set; }
        public DateTime Time { get; set; }
        public int Number { get; set; } /*Adet*/
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }
        public Current Current { get; set; }
        public Employee Employee { get; set; }


    }

}