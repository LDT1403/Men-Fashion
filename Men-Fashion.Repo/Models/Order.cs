using System;
using System.Collections.Generic;

namespace Men_Fashion.Repo.Model;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PaymentId { get; set; }

    public int? AddressId { get; set; }

    public decimal? TotalMoney { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment? Payment { get; set; }

    public virtual User? User { get; set; }
}
