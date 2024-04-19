using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safarti.Api.Models;

public class City{

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Label { get; set; } 

    [InverseProperty(nameof(Travel.FromCity))]
    public virtual IEnumerable<Travel> TravelsFrom { get; set; }

    [InverseProperty(nameof(Travel.ToCity))]
    public virtual IEnumerable<Travel> TravelsTo { get; set; }


}