namespace ApiSysSchoolar.Models;

public class SubjectFull
{
    public int idSubjectFull { get; set; }
    public string yearSf { get; set; }
    public int idScheduleSf { get; set; }
    public int idSubjectSf { get; set; }
    public int idTeacherSf { get; set; }

    public virtual Schedules? Schedules { get; set; }
    public virtual Subjects? Subjects { get; set; }
    public virtual Teachers? Teachers { get; set; }
}

