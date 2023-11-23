using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ProductStatusClass
{
    public int ProductStatusClassId { get; set; }

    public string ProductStatusClassName { get; set; } = null!;

    public virtual ICollection<ReceivingNoteItem> ReceivingNoteItems { get; } = new List<ReceivingNoteItem>();
}
