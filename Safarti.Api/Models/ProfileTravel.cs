using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Safarti.Api.Models;

public class ProfileTravel{

    public int Id { get; set; }

    [Required]
    public int TravelId { get; set; }

    [Required]
    public int ProfileId { get; set; }

    [ForeignKey(nameof(TravelId))]
    public virtual IEnumerable<Travel> Travels { get; set; } 

    [ForeignKey(nameof(ProfileId))]
    public virtual IEnumerable<Profile> Profiles { get; set; } 

}