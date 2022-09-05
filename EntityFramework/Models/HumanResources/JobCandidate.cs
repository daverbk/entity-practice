using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF.Models.Person;

namespace EF.Models.HumanResources;

[Table("JobCandidate", Schema = "HumanResources")]
public class JobCandidate
{
    [Key]
    [Column("JobCandidateID")]
    public int JobCandidateId { get; set; }

    [ForeignKey(nameof(BusinessEntity))]
    [Column("BusinessEntityID")]
    public int? BusinessEntityId { get; set; }

    public string Resume { get; set; } = string.Empty;
    
    public DateTime ModifiedDate { get; set; } 
}
