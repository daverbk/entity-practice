using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityContact", Schema = "Person")]
public class BusinessEntityContact
{
    [Key]
    [ForeignKey(nameof(BusinessEntityContact))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    [ForeignKey(nameof(BusinessEntityContact))]
    [Column("PersonID")]
    public int PersonId { get; set; }
    
    [ForeignKey(nameof(BusinessEntityContact))]
    [Column("ContactTypeID")]
    public int ContactTypeId { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
