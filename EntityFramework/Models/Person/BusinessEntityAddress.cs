using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityAddress", Schema = "Person")]
public class BusinessEntityAddress
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
