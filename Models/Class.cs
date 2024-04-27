namespace ApiSysSchoolar.Models;

public class Class
{
    public int idClass { get; set; }
    public string classroomClass { get; set; }
    public int idSchoolarLevelC { get; set; }
    public int idSubjectFullC { get; set; }

    public virtual SchoolarLevels? SchoolarLevels { get; set; }
    public virtual SubjectFull? SubjectFull { get; set; }
}