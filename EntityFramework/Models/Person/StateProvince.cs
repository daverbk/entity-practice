using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("StateProvince", Schema = "Person")]
public class StateProvince
{
    [Key]
    [Column("StateProvinceID")]
    public int StateProvinceId { get; set; }
    
    public string StateProvinceCode { get; set; } = string.Empty;
    
    [ForeignKey(nameof(CountryRegion))]
    public string CountryRegionCode { get; set; } = string.Empty;
    
    public bool IsOnlyStateProvinceFlag { get; set; }

    public string Name { get; set; } = string.Empty;
    
    [Column("TerritoryID")]
    public int TerritoryId { get; set; }

    [Column("rowguid")]
    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
