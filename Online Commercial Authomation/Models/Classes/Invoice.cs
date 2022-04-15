using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoicesId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SerialNumber { get; set; } /*Fatura Seri Numarası*/


        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string RowNumber { get; set; }/*Fatura Sıra Numarası*/

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAuthority { get; set; } /*Vergi Dairesi*/

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; } /*Teslim Eden*/

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; } /*Teslim Alan*/

        public decimal Total { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }

}