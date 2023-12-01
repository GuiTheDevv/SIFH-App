using System.Reflection.Metadata;
using SIFHApp.Models;

// public class DataView {
//     public List<Vessel>? Vessels {get; set;}
//     public List<Product>? Products {get; set;}
//     public List<GradeClass>? GradeClasses {get; set;}
// }

// public class FormData {
//     public int referenceNumber { get; set; }
//     public int vesselID { get; set; }
//     public int catchID { get; set;}
//     public string? catchName { get; set; }
//     public decimal weight { get; set; }
//     public int gradeID { get; set; }
//     public string? grade { get; set; }
//     public decimal temperature { get; set; }
    
// }

public class FormDataViewModel
{
    public List<Vessel> Vessels { get; set; }
    public List<Product> Products { get; set; }
    public List<GradeClass> GradeClasses { get; set; }
    public List<FormData> SubmittedDataList { get; set; }
    public int? LastReferenceNumber { get; set; }
    public int? LastVesselID { get; set; }

    // Constructor to initialize lists
    public FormDataViewModel()
    {
        Vessels = new List<Vessel>();
        Products = new List<Product>();
        GradeClasses = new List<GradeClass>();
        SubmittedDataList = new List<FormData>();
    }
}
