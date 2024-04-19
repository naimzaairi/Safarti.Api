using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Safarti.Api.Models;

public class User : IdentityUser{

    [InverseProperty(nameof(Profile.User))]
    public virtual Profile Profile { get; set; }

}