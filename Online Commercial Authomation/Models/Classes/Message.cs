using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Buyer { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

    }
}