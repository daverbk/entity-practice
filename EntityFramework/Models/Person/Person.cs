using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Person", Schema = "Person")]
public class Person
{
    [Key]
    public int BusinessEntityID { get; set; }
    
    public int PersonType { get; set; }
    
    public int NameStyle { get; set; }
    
    public int Title { get; set; }
    
    public int FirstName { get; set; }
    
    public int MiddleName { get; set; }
    
    public int LastName { get; set; }
    
    public int Suffix { get; set; }
    
    public int EmailPromotion { get; set; }
    
    public int AdditionalContactInfo { get; set; }
    
    public int Demographics { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
