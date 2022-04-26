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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public int Number { get; set; } /*Adet*/
        public decimal Price { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        public int ProductsId { get; set; }
        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }


    }

}