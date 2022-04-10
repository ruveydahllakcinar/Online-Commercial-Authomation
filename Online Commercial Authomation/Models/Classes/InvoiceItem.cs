using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class InvoiceItem /*Fatura Kalemi*/
    {
        [Key]
        public int InvoiceItemId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; } /*Açıklama*/
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public Invoice Invoices { get; set; }
    }

}