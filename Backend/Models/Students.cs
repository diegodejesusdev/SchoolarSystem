namespace ApiSysSchoolar.Models;

public class Students
{
    public int idStudent { get; set; }
    public string nameStudent { get; set; }
    public string ccStudent { get; set; }
    public string emailStudent { get; set; }
    public string phoneStudent { get; set; }
    public int idSchoolarLevelS { get; set; }

    public virtual SchoolarLevels? SchoolarLevels { get; set; }
}