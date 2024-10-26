using System.ComponentModel.DataAnnotations;

namespace WetBusinessApp.Presentation.Contracts.Login
{
    public record LoginRequest
    {
        [Required]
        public string? UserName { get; set; }
       
        [Required]
        public string? Password { get; set; }

    }
}
