using System;
using System.Collections.Generic;

namespace SIFHApp.Models;

public partial class CustomerFile
{
    public int CustomerId { get; set; }

    public byte[]? CustomerDocument { get; set; }
}
