using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntity", Schema = "Person")]
public class BusinessEntity
{
    public int BusinessEntityID { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
