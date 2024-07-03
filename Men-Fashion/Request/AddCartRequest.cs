namespace Men_Fashion.Request
{
    public class AddCartRequest
    {
        public int? ProductId { get; set; } = null!;
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
    }
}
