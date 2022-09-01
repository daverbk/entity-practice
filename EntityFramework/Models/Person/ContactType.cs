using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("ContactType", Schema = "Person")]
public class ContactType
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
