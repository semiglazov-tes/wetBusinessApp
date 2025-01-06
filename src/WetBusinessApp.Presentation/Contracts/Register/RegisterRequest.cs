using System.ComponentModel.DataAnnotations;

namespace WetBusinessApp.Presentation.Contracts.Register;

public record RegisterRequest
{
     [Required]
     public string? UserName { get; set; }
     [Required]
     public string? UserEmail { get; set; }
     [Required]
     public string? Password { get; set; }
}
