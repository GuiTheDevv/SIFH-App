using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class PackingList
{
    public int PackingListId { get; set; }

    public int CustomerId { get; set; }

    public string? InvoiceNumber { get; set; }

    public DateTime? DateCreated { get; set; }

    public int StatusClassId { get; set; }

    public int AirlineId { get; set; }

    public int? BoxNumber { get; set; }

    public decimal? Weight { get; set; }

    public string? BoatName { get; set; }

    public int? ReceivingNoteItemId { get; set; }

    public int? PackingListNumber { get; set; }

    public string? ProductionDate { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ReceivingNoteItem> ReceivingNoteItems { get; } = new List<ReceivingNoteItem>();
}
