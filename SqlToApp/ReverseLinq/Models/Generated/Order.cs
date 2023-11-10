using System;
using System.Collections.Generic;

namespace ReverseLinq.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderPlaced { get; set; }

    public DateTime OrderFulfilled { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
