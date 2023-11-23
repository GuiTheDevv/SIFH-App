using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal CurrentUnitPrice { get; set; }

    public virtual ICollection<ProductUnitePriceHistory> ProductUnitePriceHistories { get; } = new List<ProductUnitePriceHistory>();

    public virtual ICollection<ReceivingNoteItem> ReceivingNoteItems { get; } = new List<ReceivingNoteItem>();
}
