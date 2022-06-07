using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Models
{
    internal class OrderHeader
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int PartnerId { get; set; }

        public User User { get; set; }
        public Partner Partner { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
