using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Person", Schema = "Person")]
public class Person
{
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }
     
    public string PersonType { get; set; } = string.Empty;

    public bool NameStyle { get; set; } 
    
    public string? Title { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    
    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;
    
    public string? Suffix { get; set; }
    
    public int EmailPromotion { get; set; }
    
    public string? AdditionalContactInfo { get; set; }

    public string? Demographics { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
