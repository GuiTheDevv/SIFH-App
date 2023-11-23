using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class PackingListListView
{
    public int PackingListId { get; set; }

    public string? InvoiceNumber { get; set; }

    public DateTime? DateCreated { get; set; }

    public int StatusClassId { get; set; }

    public string StatusClassName { get; set; } = null!;

    public string? AirlineName { get; set; }

    public string? CustomerName { get; set; }

    public int CustomerId { get; set; }
}
