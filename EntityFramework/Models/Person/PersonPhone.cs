using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("PersonPhone", Schema = "Person")]
public class PersonPhone
{
    [Key]
    [ForeignKey(nameof(Person))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
    
    [ForeignKey(nameof(PhoneNumberType))]
    [Column("PhoneNumberTypeID")]
    public int PhoneNumberTypeId { get; set; }

    public DateTime ModifiedDate { get; set; }
}
