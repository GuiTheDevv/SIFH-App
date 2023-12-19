using System.Reflection.Metadata;
using SIFHApp.Models;

public class EditDataViewModel
{
    public List<Vessel>? Vessels { get; set; }
    public List<Product>? Products { get; set; }
    public List<GradeClass>? GradeClasses { get; set; }
    public FormData? Item { get; set; }
}
