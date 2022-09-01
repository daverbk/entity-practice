using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("AddressType", Schema = "Person")]
public class AddressType
{
    public int AddressTypeID { get; set; }

    public string Name { get; set; } = string.Empty;
    
    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
