using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ValidateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Code { get; set; }
}