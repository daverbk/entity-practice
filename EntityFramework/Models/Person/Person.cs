using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Person", Schema = "Person")]
public class Person
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
