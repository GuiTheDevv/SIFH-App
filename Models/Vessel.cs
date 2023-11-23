using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class Vessel
{
    public int VesselId { get; set; }

    public string VesselName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? RegistrationNumber { get; set; }

    public DateTime DateCreated { get; set; }

    public bool SoftDeleted { get; set; }

    public virtual ICollection<ReceivingNote> ReceivingNotes { get; } = new List<ReceivingNote>();
}
