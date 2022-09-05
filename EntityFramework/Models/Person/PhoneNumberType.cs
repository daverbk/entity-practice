using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("PhoneNumberType", Schema = "Person")]
public class PhoneNumberType
{
    [Key]
    [Column("PhoneNumberTypeID")]
    public int PhoneNumberTypeId { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public DateTime ModifiedDate { get; set; }
}
