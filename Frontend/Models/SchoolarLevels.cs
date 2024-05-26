using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class SchoolarLevels
{
    public int idSchoolarLevel { get; set; }
    [Required(ErrorMessage = "Level is required")]
    [StringLength(25, ErrorMessage = "Level name is very long. Max. 15 characters")]
    public string nameLevel { get; set; }
    [Required(ErrorMessage = "Sublevel is required")]
    public int idSublevelSL { get; set; }

    public virtual SubLevels? SubLevels { get; set; }

    /*SchoolarLevels()
    {
        nameLevel = String.Empty;
        SubLevels = null;
    }*/

    public SchoolarLevels(int idSchoolarLevel, string nameLevel, int idSublevelSl, SubLevels? subLevels)
    {
        this.idSchoolarLevel = idSchoolarLevel;
        this.nameLevel = nameLevel;
        idSublevelSL = idSublevelSl;
        SubLevels = subLevels;
    }

    public SchoolarLevels()
    {
     
    }
}