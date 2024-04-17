namespace ApiSysSchoolar.Models;

public class Notes
{
    public int idNote { get; set; }
    public float noteN { get; set; }
    public int idStudentN { get; set; }
    public int idSubjectFullN { get; set; }

    public virtual Students Students { get; set; } = null!;
    public virtual SubjectFull SubjectFull { get; set; } = null!;
}

