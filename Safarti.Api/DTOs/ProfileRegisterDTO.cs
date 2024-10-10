using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Safarti.Api.Models.DTOs;

public class ProfileRegisterDTO{

    public int UserId { get; set; }
    public int GenderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int NationalityId { get; set; }
    public string IdNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string CarIdentication { get; set; }    



}