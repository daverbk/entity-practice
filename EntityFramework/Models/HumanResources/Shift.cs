using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.HumanResources;

[Table("Shift", Schema = "HumanResources")]
public class Shift
{
    [Key]
    [Column("ShiftID")]
    public byte ShiftId { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
    
    public DateTime ModifiedDate { get; set; } 
}
