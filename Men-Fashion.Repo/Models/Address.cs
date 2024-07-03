using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Models;

public partial class Address
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Address1 { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
