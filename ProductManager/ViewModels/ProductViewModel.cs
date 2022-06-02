using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.ViewModels
{
    internal class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string ProductType { get; set; }
        public string PartnerName { get; set; }
    }
}
