using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("EmailAddress", Schema = "Person")]
public class EmailAddress
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
