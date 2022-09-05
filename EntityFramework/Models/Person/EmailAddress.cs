using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("EmailAddress", Schema = "Person")]
public class EmailAddress
{
    [Key]
    [Column("EmailAddressID")]
    public int EmailAddressId { get; set; }

    [ForeignKey(nameof(Person))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }
    
    [Column("EmailAddress")] 
    public string Address { get; set; } = string.Empty;

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
