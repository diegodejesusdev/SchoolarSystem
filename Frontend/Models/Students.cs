using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class  Students
{
    public int idStudent { get; set; }
    [Required (ErrorMessage = "Name is required")]
    [StringLength(45, ErrorMessage = "Name is very long. (Max. 45 characters)")]
    public string nameStudent { get; set; }
    [Required (ErrorMessage = "CC is required")]
    [StringLength(15, ErrorMessage = "CC is very long. (Max. 15 numbers)")]
    public string ccStudent { get; set; }
    [Required (ErrorMessage = "Email is required")]
    [StringLength(45, ErrorMessage = "Email is very long. (Max. 45 characters)")]
    public string emailStudent { get; set; }
    [Required (ErrorMessage = "Phone is required")]
    [StringLength(15, ErrorMessage = "Phone is very long. (Max. 15 numbers)")]
    public string phoneStudent { get; set; }
    [Required (ErrorMessage = "Schoolar Level is required")]
    public int idSchoolarLevelS { get; set; }

    public virtual SchoolarLevels? SchoolarLevels { get; set; }

    public Students()
    {
        nameStudent = string.Empty;
        ccStudent = String.Empty;
        emailStudent = String.Empty;
        phoneStudent = String.Empty;
        SchoolarLevels = null;
    }

    public Students(int idStudent, string nameStudent, string ccStudent, string emailStudent, string phoneStudent, int idSchoolarLevelS, SchoolarLevels? schoolarLevels)
    {
        this.idStudent = idStudent;
        this.nameStudent = nameStudent;
        this.ccStudent = ccStudent;
        this.emailStudent = emailStudent;
        this.phoneStudent = phoneStudent;
        this.idSchoolarLevelS = idSchoolarLevelS;
        SchoolarLevels = schoolarLevels;
    }
}