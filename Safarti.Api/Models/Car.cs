using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safarti.Api.Models;

public class Car{

    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Brand { get; set; } 

    [Required]
    [StringLength(25)]
    public string Model { get; set; } 

    [InverseProperty(nameof(Profile.Car))]
    public virtual IEnumerable<Profile> Profiles { get; set; }
}