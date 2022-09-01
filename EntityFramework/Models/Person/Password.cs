using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Password", Schema = "Person")]
public class Password
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
