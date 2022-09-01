using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Sales;

[Table("SalesOrderHeader", Schema = "Sales")]
public class SalesOrderHeader
{
    public int AddressID { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;
    
    public string? AddressLine2 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
    
    public int StateProvinceID { get; set; }

    public string PostalCode { get; set; } = string.Empty;

    public string SpatialLocation { get; set; } = string.Empty;
    
    public Guid rowguid { get; set; } 
    
    public DateTime ModifiedDate { get; set; } 
}
