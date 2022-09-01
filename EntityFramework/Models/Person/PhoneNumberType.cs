using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("PhoneNumberType", Schema = "Person")]
public class PhoneNumberType
{
    public int BusinessEntityID { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
