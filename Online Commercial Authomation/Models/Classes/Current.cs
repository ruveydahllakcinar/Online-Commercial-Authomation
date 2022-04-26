using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class Current /*Cari*/
    {
        [Key]
        public int CurrentId { get; set; }
        [Display(Name = "Current Name")]
        [Column(TypeName = "Varchar")]
        public string CurrentName { get; set; }

        [Display(Name = "Current Surname")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }

        [Display(Name = "Current City")]
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CurrentCity { get; set; }

        [Display(Name = "Current Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }
        public bool Situation { get; set; }

        public ICollection<SaleMove> SaleMoves { get; set; }

    }
}
