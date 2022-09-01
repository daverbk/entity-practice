using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("EmailAddress", Schema = "Person")]
public class EmailAddress
{
    public int BusinessEntityID { get; set; }
    
    public int EmailAddressID { get; set; }

    [Column("EmailAddress")] 
    public string Address { get; set; } = string.Empty;

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
