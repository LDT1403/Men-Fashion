﻿namespace Men_Fashion.Response
{
    public class CartResponse
    {
        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string? ProductName { get; set; }

        public string? Thumbnail { get; set; }

        public int? Inventory { get; set; }
    }
    public class CountCart {
        public int count { get; set; }
    }

}
