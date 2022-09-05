using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntity", Schema = "Person")]
public class BusinessEntity
{
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
