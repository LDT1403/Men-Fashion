namespace Men_Fashion.Request
{
    public class ProductRequest
    {
        public decimal? Price { get; set; }

        public string? ProductName { get; set; }

        public string? Thumbnail { get; set; }

        public string? Description { get; set; }

        public int? Inventory { get; set; }

        public int? CategoryId { get; set; }
    }
}
