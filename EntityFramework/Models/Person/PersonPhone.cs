using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("PersonPhone", Schema = "Person")]
public class PersonPhone
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
