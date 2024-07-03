using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Model;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
