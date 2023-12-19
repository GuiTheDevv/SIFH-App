using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

public class FormData {
    public string? ReferenceNumber { get; set; }
    public int VesselID { get; set; }
    public int CatchID { get; set;}
    public string? CatchName { get; set; }
    public decimal Weight { get; set; }
    public int GradeID { get; set; }
    public string? Grade { get; set; }
    public decimal? Temperature { get; set; }
    public byte[]? ImageData { get; set; }
    
}