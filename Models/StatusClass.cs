using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class StatusClass
{
    public int StatusClassId { get; set; }

    public string StatusClassName { get; set; } = null!;

    public virtual ICollection<ReceivingNote> ReceivingNotes { get; } = new List<ReceivingNote>();
}
