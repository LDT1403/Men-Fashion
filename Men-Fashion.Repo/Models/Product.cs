﻿using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Models;

public partial class Product
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public string? ProductName { get; set; }

    public string? Thumbnail { get; set; }

    public string? Description { get; set; }

    public int? Inventory { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}