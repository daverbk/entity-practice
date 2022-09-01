using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Person;

[Table("ContactType", Schema = "Person")]
public class ContactType
{
    public int ContactTypeID { get; set; }

    public string Name { get; set; }

    public DateTime ModifiedDate { get; set; }
}
