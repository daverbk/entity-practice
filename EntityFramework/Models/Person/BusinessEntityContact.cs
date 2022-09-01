using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("BusinessEntityContact", Schema = "Person")]
public class BusinessEntityContact
{
    [Key]
    public int BusinessEntityID { get; set; }

    public int PersonID { get; set; }
    
    public int ContactTypeID { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
