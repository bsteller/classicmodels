using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicModels.Models
 {
    public class ProductLines
    {
        [Column("productLineId")]
        public int ProductLineId { get; set; }

        [Column("productLine")]
        public string ProductLine { get; set; }

        [Column("textDescription")]
        public string TextDescription { get; set; }

        [Column("image")]
        public string Image { get; set; }
    }
}