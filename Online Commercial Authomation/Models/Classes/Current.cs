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
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        public string CurrentName { get; set; }
      
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CurrentSurname { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CurrentCity { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }
        public bool Situation { get; set; }

        public ICollection<SaleMove> SaleMoves { get; set; }

    }
}
