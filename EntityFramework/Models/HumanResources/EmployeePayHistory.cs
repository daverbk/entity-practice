using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF.Models.Person;

namespace EF.Models.HumanResources;

[Table("EmployeePayHistory", Schema = "HumanResources")]
public class EmployeePayHistory
{
    [Key]
    [ForeignKey(nameof(BusinessEntity))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    public DateTime RateChangeDate { get; set; }
    
    [Column(TypeName = "money")]
    public decimal Rate { get; set; }

    public byte PayFrequency { get; set; }

    public DateTime ModifiedDate { get; set; }
}
