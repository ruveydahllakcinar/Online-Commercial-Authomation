using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Commercial_Authomation.Models.Classes
{
    public class ProductDetail
    {
        public IEnumerable<Product> Values1 { get; set; }
        public IEnumerable<PDetail> Values2 { get; set; }
    }
}