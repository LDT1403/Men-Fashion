using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Model;

public partial class Payment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? TotalMoney { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
