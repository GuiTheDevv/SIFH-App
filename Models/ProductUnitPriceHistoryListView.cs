using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ProductUnitPriceHistoryListView
{
    public string ProductName { get; set; } = null!;

    public decimal UnitPriceOld { get; set; }

    public decimal UnitPriceNew { get; set; }

    public DateTime DateChanged { get; set; }

    public int ProductId { get; set; }

    public int ProductUnitPriceHistoryId { get; set; }
}
