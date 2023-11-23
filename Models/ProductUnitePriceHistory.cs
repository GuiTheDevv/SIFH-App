using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ProductUnitePriceHistory
{
    public int ProductUnitPriceHistoryId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPriceOld { get; set; }

    public decimal UnitPriceNew { get; set; }

    public DateTime DateChanged { get; set; }

    public virtual Product Product { get; set; } = null!;
}
