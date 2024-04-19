using System.ComponentModel.DataAnnotations.Schema;

namespace Safarti.Api.Models;

public class Gender {
    public int Id { get; set; }
    public string Label { get; set; }

    [InverseProperty(nameof(Profile.Gender))]
    public virtual IEnumerable<Profile> Profiles { get; set; }

}