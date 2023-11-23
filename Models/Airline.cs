using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class Airline
{
    public int AirlineId { get; set; }

    public string? AirlineName { get; set; }

    public virtual ICollection<PackingList> PackingLists { get; } = new List<PackingList>();
}
