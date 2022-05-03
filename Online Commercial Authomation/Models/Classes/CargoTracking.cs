using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }
}