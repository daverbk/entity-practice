using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF.Models.Person;

namespace EF.Models.HumanResources;

[Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
public class EmployeeDepartmentHistory
{
    [Key]
    [ForeignKey(nameof(BusinessEntity))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    [ForeignKey(nameof(Department))]
    [Column("DepartmentID")]
    public short DepartmentId { get; set; } 

    [ForeignKey(nameof(Shift))]
    [Column("ShiftID")]
    public byte ShiftId { get; set; } 

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
