using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class SubLevels
{
    public int idSublevel { get; set; }
    [Required (ErrorMessage = "Sublevel is required")]
    [StringLength(15, ErrorMessage = "Sublevel is very long. Max. 15 characters")]
    public string nameSublevel { get; set; }
    [Required (ErrorMessage = "Year is required (yyyy-mm-dd)")]
    public string yearSublevel { get; set; }
}