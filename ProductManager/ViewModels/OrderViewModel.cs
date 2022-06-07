using System;

namespace ProductManager.ViewModels
{
    internal class OrderViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Products { get; set; }
    }
}
