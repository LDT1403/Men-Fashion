namespace Men_Fashion.Request
{
    public class OrderRequest
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? AddressDetail { get; set; }
        public string? PaymentMethod { get; set; }
        public List<ListOrder> listOrders { get; set; } = new List<ListOrder>();

    }
    public class ListOrder
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
