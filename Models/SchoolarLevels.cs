namespace ApiSysSchoolar.Models;

public class SchoolarLevels
{
    public int idSchoolarLevel { get; set; }
    public string nameLevel { get; set; }

    public virtual SubLevels SubLevels { get; set; } = null!;
}