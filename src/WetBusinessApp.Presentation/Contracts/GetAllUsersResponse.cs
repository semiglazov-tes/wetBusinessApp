using System.ComponentModel.DataAnnotations;
using WetBusinessApp.Domain;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Presentation.Contracts
{
    public record GetAllUsersResponse
    {
        [Required]
        public List<User> Users { get; set; }
        
    }
}
