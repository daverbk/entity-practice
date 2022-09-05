using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("ContactType", Schema = "Person")]
public class ContactType
{
    [Key]
    [Column("ContactTypeID")]
    public int ContactTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime ModifiedDate { get; set; }
}
