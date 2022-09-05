using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("AddressType", Schema = "Person")]
public class AddressType
{
    [Key]
    [Column("AddressTypeID")]
    public int AddressTypeId { get; set; }

    public string Name { get; set; } = string.Empty;
    
    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
