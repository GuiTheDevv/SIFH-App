using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public bool SoftDeleted { get; set; }

    public virtual ICollection<PackingList> PackingLists { get; } = new List<PackingList>();
}
