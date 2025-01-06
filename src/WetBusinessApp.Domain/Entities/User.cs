
namespace WetBusinessApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; }
        public string UserName { get; }
        public string UserEmail { get; }
        public string PasswordHash { get; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        private User(Guid id, string userName, string userEmail, string passHash, string? refreshToken = null, DateTime? refreshTokenExpiryTime = null)
        {
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            PasswordHash = passHash;
            RefreshToken = refreshToken;
            RefreshTokenExpiryTime = refreshTokenExpiryTime;
        }
        public static User Create(Guid id, string userName, string userEmail, string passwordHash, string? refreshToken = null, DateTime? refreshTokenExpiryTime = null)
        {
            return new User(id, userName, userEmail, passwordHash, refreshToken, refreshTokenExpiryTime);
        }

    }
}
