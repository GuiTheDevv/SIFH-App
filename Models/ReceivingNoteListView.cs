using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ReceivingNoteListView
{
    public int ReceivingNoteId { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalPayments { get; set; }

    public int VesselId { get; set; }

    public string VesselName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public int StatusClassId { get; set; }

    public string StatusClassName { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? CheckNumber1 { get; set; }

    public string? CheckNumber2 { get; set; }

    public decimal? TotalQuantity { get; set; }

    public decimal? AveragePrice { get; set; }

    public decimal? OrderTotal { get; set; }

    public decimal? TotalDue { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? ReferenceNumber { get; set; }
}
