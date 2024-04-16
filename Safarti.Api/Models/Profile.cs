using System.ComponentModel.DataAnnotations;

namespace Safarti.Api.Models;

public class Profile{

    public int Id { get; set; }
    [StringLength(255)]
    public string Label { get; set; } = "";
}