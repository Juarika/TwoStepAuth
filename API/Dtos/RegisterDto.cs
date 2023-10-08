using System.ComponentModel.DataAnnotations;
using System;

namespace API.Dtos;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }
}
