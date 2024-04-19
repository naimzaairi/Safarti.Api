using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Tar;
using Microsoft.AspNetCore.Identity;
using Safarti.Api.Constants;

namespace Safarti.Api.Models;

public class Profile{

    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } 

    [Required]
    public int GenderId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [StringLength(3)]
    public string Nationality { get; set; }

    [Required]
    [StringLength(25)]
    public string IdNumber { get; set; }

    [Required]
    [StringLength(25)]
    public string Address { get; set; }

    [Required]
    [StringLength(25)]
    public string PhoneNumber { get; set; }

    [Required]
    public int OrganizedTravels { get; set; }

    [Required]
    public int ParticipatedTravels { get; set; }

    [Required]
    public bool Certified { get; set; } = false;

    [Required]
    public bool Verified { get; set; } = false;

    [Required]
    [StringLength(25)]
    public string CarIdentication { get; set; }    

    [ForeignKey(nameof(GenderId))]
    public virtual Gender Gender { get; set; }

    [Required]
    public int CarId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual IdentityUser User { get; set; } 

    [ForeignKey(nameof(CarId))]
    public virtual Car Car { get; set; } 

    [InverseProperty(nameof(Travel.Profile))]
    public virtual IEnumerable<Travel> Travels { get; set; }

    [InverseProperty(nameof(ProfileRanking.Profile))]
    public virtual IEnumerable<ProfileRanking> ProfileRankings { get; set; }

    public virtual IEnumerable<ProfileTravel> ProfileTravels { get; set; }


    // [InverseProperty(nameof(ProfileTravel.Profiles))]
    // public virtual IEnumerable<ProfileTravel> ProfileTravels { get; set; }



}