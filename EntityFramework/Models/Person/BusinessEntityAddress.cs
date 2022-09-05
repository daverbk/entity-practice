using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityAddress", Schema = "Person")]
public class BusinessEntityAddress
{
    [Key]
    [ForeignKey(nameof(BusinessEntityAddress))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }
    
    [ForeignKey(nameof(BusinessEntityAddress))]
    [Column("AddressID")]
    public int AddressI { get; set; }
    
    [ForeignKey(nameof(BusinessEntityAddress))]
    [Column("AddressTypeID")]
    public int AddressTypeId { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
