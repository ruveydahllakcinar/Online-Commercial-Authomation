using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductsId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Product Brand")]
        public string ProductBrand { get; set; } /*Marka*/
        public short Stock { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; } /*Alış Fiyatı*/
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; } /*Satış Fiyatı*/
        public bool Situation { get; set; } /*Durum*/ /*Ürünün kritik seviyede olup olmadığını göstereceğiz*/



        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<SaleMove> SaleMoves { get; set; }


    }

}