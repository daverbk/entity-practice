using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.models;

[Table("EmployeePayHistory", Schema = "HumanResources")]
public class EmployeePayHistory
{
    [Key]
    public int BusinessEntityID { get; set; }
    
    public DateTime RateChangeDate { get; set; }
    
    [Column(TypeName = "money")]
    public decimal Rate { get; set; }

    public byte PayFrequency { get; set; }

    public DateTime ModifiedDate { get; set; }
}
