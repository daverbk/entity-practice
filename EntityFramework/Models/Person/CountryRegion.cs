using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("CountryRegion", Schema = "Person")]
public class CountryRegion
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
