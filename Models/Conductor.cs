using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class Conductor
{
    public int ConductorId { get; set; }

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LicenseNumber { get; set; }
}
