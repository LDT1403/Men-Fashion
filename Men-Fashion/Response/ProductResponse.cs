namespace Men_Fashion.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public string ProductName { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public int? Inventory { get; set; }
        public int? CategoryId { get; set; }
    }
}
