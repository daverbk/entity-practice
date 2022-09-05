using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Password", Schema = "Person")]
public class Password
{
    [Key]
    [ForeignKey(nameof(Person))]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }
    
    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordSalt { get; set; } = string.Empty;
    
    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
