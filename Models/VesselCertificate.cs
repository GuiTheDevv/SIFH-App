using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class VesselCertificate
{
    public int VesselId { get; set; }

    public byte[]? VesselDocument { get; set; }
}
