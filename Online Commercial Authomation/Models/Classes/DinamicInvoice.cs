using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class DinamicInvoice
    {
        public IEnumerable<Invoice>Invoices { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItems  { get; set; }
    }
}