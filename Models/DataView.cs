using System.Reflection.Metadata;
using SIFHApp.Models;

public class FormDataViewModel
{
    public List<Vessel> Vessels { get; set; }
    public List<Product> Products { get; set; }
    public List<ProductStatusClass> ProductStatusClasses { get; set; } 
    public List<GradeClass> GradeClasses { get; set; }
    public List<FormData> SubmittedDataList { get; set; }
    public string? LastReferenceNumber { get; set; }
    public int? LastVesselID { get; set; }

    // Constructor to initialize lists
    public FormDataViewModel()
    {
        Vessels = new List<Vessel>();
        Products = new List<Product>();
        GradeClasses = new List<GradeClass>();
        ProductStatusClasses = new List<ProductStatusClass>();
        SubmittedDataList = new List<FormData>();
    }
}
