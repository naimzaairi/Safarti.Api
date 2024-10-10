using System.ComponentModel.DataAnnotations;

namespace Safarti.Api.Models.DTOs;

public class ResponseDTO 
{
    public bool Success { get; set; }
    public int IdCreated { get; set; }
    public string Error { get; set; }
}