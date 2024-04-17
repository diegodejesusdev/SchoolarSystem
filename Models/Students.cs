namespace ApiSysSchoolar.Models;

public class Students
{
    public int idStudent { get; set; }
    public string nameStudent { get; set; }
    public string ccStudent { get; set; }
    public string phoneStudent { get; set; }
    public int idSublevelS { get; set; }

    public virtual SubLevels SubLevels { get; set; } = null!;
}