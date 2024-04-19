using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safarti.Api.Models;

public class ProfileRanking{

    public int Id { get; set; }

    [Required]
    public int ProfileId { get; set; }

    [Required]
    public int Ranking { get; set; } 

    [Required]
    [StringLength(255)]
    public string Comment { get; set; } 

    [ForeignKey(nameof(ProfileId))]
    public virtual Profile Profile { get; set; }

}