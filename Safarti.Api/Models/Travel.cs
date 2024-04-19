using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Safarti.Api.Constants;

namespace Safarti.Api.Models;

public class Travel{

    public int Id { get; set; }

    [Required]
    public int ProfileId { get; set; }

    [Required]
    public DateTime DepartureDate { get; set; } 

    [Required]
    [StringLength(50)]
    public string MeetingPlace { get; set; } 

    [Required]
    public int Places { get; set; } 

    [Required]
    [StringLength(255)]
    public string OtherInformation { get; set; } 

    [Required]
    
    public int FromCityId { get; set; } 

    [Required]
    public int ToCityId { get; set; } 

    [Required]
    [ForeignKey(nameof(ProfileId))]
    public virtual Profile Profile { get; set; } 

    [ForeignKey(nameof(FromCityId))]
    public virtual City FromCity { get; set; } 

    [ForeignKey(nameof(ToCityId))]
    public virtual City ToCity { get; set; } 

    public virtual IEnumerable<ProfileTravel> ProfileTravels { get; set; }
}