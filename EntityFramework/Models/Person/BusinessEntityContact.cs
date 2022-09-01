using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityContact", Schema = "Person")]
public class BusinessEntityContact
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
