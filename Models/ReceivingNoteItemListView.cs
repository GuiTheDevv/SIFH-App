using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ReceivingNoteItemListView
{
    public int ReceivingNoteItemId { get; set; }

    public int ReceivingNoteId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Temperature { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal CurrentUnitPrice { get; set; }

    public int GradeClassId { get; set; }

    public string GradeClassName { get; set; } = null!;

    public decimal? LineTotal { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? OrderDate { get; set; }

    public string VesselName { get; set; } = null!;

    public int VesselId { get; set; }

    public int ProductStatusClassId { get; set; }

    public string ProductStatusClassName { get; set; } = null!;

    public int? PackingListId { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? SpeciesCode { get; set; }
}
