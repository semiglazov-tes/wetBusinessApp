using System.ComponentModel.DataAnnotations;

namespace WetBusinessApp.Presentation.Contracts;

public record RegisterUserRequest
{
     [Required]
     public string? UserName { get; set; }
     [Required]
     public string? UserEmail { get; set; }
     [Required]
     public string? Password { get; set; }
}
