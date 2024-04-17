namespace ApiSysSchoolar.Models;

public class Class
{
    public int idClass { get; set; }
    public string classroomClass { get; set; }
    public int idSublevelC { get; set; }
    public int idSubjectFullC { get; set; }

    public virtual SubLevels SubLevels { get; set; } = null!;
    public virtual SubjectFull SubjectFull { get; set; } = null!;
}