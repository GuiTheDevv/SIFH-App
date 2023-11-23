using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class ReceivingNoteProductBreakdownListView
{
    public int ReceivingNoteId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int GradeClassId { get; set; }

    public string GradeClassName { get; set; } = null!;

    public decimal? Qty { get; set; }

    public decimal? SubTotal { get; set; }
}
