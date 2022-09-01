using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.HumanResources;

[Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
public class EmployeeDepartmentHistory
{
    [Key]
    public int BusinessEntityID { get; set; }

    public short DepartmentID { get; set; } 

    public byte ShiftID { get; set; } 

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
