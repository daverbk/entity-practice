using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityAddress", Schema = "Person")]
public class BusinessEntityAddress
{
    [Key]
    public int BusinessEntityID { get; set; }
    
    public int AddressID { get; set; }
    
    public int AddressTypeID { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
