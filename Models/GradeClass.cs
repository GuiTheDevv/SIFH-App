using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class GradeClass
{
    public int GradeClassId { get; set; }

    public string GradeClassName { get; set; } = null!;

    public virtual ICollection<ReceivingNoteItem> ReceivingNoteItems { get; } = new List<ReceivingNoteItem>();
}
