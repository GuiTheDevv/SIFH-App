using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class PackingListReport1
{
    public int Id { get; set; }

    public int PackingListId { get; set; }

    public int CustomerId { get; set; }

    public string? InvoiceNumber { get; set; }

    public DateTime? DateCreated { get; set; }

    public int StatusClassId { get; set; }

    public int AirlineId { get; set; }

    public int BoxNumber { get; set; }

    public decimal Weight { get; set; }

    public string? BoatName { get; set; }
}
