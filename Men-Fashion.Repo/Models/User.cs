using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? CodeEmail { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Avatar { get; set; }

    public string? Role { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
