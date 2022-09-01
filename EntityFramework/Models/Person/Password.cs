using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Password", Schema = "Person")]
public class Password
{
    [Key]
    public int BusinessEntityID { get; set; }
    
    public string PasswordHash { get; set; }

    public string PasswordSalt { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
