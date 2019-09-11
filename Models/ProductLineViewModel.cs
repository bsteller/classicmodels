using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicModels.Models
{
    public class ProductLineViewModel : PageViewModel
    {
        public int ProductLineId { get; set; }
        public string PageTitle { get; set; }
        public List<ProductLines> ProductLines { get; set; }
        public List<Product> products { get; set; }
        public Product product { get; set; }
    }
}