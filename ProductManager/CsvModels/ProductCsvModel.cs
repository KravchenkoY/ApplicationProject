namespace ProductManager.CsvModels
{
    internal class ProductCsvModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string ProductType { get; set; }
        public int PartnerId { get; set; }
    }
}
