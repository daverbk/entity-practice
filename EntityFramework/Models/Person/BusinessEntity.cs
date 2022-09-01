using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntity", Schema = "Person")]
public class BusinessEntity
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
