using System.ComponentModel.DataAnnotations.Schema;

namespace WetBusinessApp.Infrastructure.Storage.Entity
{
    [Table("Users")]
    public class UserEntity
    {
        [Column("Id")]
        public Guid Id { get;}

        [Column("Name")]
        public string UserName { get;}

        [Column("Email")]
        public string UserEmail { get;}

        [Column("Password")]
        public string PasswordHash { get;}
        
        [Column("RefreshToken")]
        public string? RefreshToken { get; set; }
        
        [Column("RefreshTokenExpiryTime")]
        public DateTime? RefreshTokenExpiryTime { get; set; }
        
        private UserEntity(string userName, string userEmail, string passwordHash, string? refreshToken = null, DateTime? refreshTokenExpiryTime = null)
        {
            UserName = userName;
            UserEmail = userEmail;
            PasswordHash = passwordHash;
            RefreshToken = refreshToken;
            RefreshTokenExpiryTime = refreshTokenExpiryTime;
        }
        public static UserEntity Create(string userName, string userEmail, string passwordHash, string? refreshToken = null, DateTime? refreshTokenExpiryTime = null)
        {
            return new UserEntity(userName, userEmail, passwordHash, refreshToken, refreshTokenExpiryTime);
        }
    }
}
