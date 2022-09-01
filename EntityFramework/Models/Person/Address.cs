using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("Address", Schema = "Person")]
public class Address
{
    public int AddressID { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;
    
    public string? AddressLine2 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
    
    public int StateProvinceID { get; set; }

    public string PostalCode { get; set; } = string.Empty;

    public string SpatialLocation { get; set; } = string.Empty;
    
    [Column("rowguid")]
    public Guid RowGuid { get; set; } 
    
    public DateTime ModifiedDate { get; set; } 
}
