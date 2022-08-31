using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace EF.models;

[Table("JobCandidate", Schema = "HumanResources")]
public class JobCandidate
{
    [Key]
    public int JobCandidateID { get; set; }

    public int? BusinessEntityID { get; set; }

    public string Resume { get; set; }

    public DateTime ModifiedDate { get; set; } 
}
