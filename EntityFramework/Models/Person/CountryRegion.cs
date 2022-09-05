using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("CountryRegion", Schema = "Person")]
public class CountryRegion
{
    [Key]
    public string CountryRegionCode { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime ModifiedDate { get; set; }
}
