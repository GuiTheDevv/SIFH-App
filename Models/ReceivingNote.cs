using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ReceivingNote
{
    public int ReceivingNoteId { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? OrderDate { get; set; }

    public int VesselId { get; set; }

    public int StatusClassId { get; set; }

    public decimal TotalPayments { get; set; }

    public string? CheckNumber1 { get; set; }

    public string? CheckNumber2 { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<ReceivingNoteItem> ReceivingNoteItems { get; } = new List<ReceivingNoteItem>();

    public virtual StatusClass StatusClass { get; set; } = null!;

    public virtual Vessel Vessel { get; set; } = null!;
}
