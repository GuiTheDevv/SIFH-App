using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class PackingListDetail
{
    public int PackingListDetailsId { get; set; }

    public int PackingListId { get; set; }

    public int ReceivingNoteItemId { get; set; }

    public int BoxNumber { get; set; }
}
