using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SIFHApp.Models;

public partial class ReceivingNoteItem
{
    public int ReceivingNoteItemId { get; set; }

    public int ReceivingNoteId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? LineTotal { get; set; }

    public decimal? Temperature { get; set; }

    public int GradeClassId { get; set; }

    public int ProductStatusClassId { get; set; }

    public int? PackingListId { get; set; }

    public string? SpeciesCode { get; set; }

    public int? PackingListNumber { get; set; }

    public byte[]? Image { get; set; }

    public virtual GradeClass GradeClass { get; set; } = null!;

    public virtual PackingList? PackingList { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductStatusClass ProductStatusClass { get; set; } = null!;

    public virtual ReceivingNote ReceivingNote { get; set; } = null!;
}
