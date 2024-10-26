
namespace WetBusinessApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string PasswordHash { get; private set; }
        private User(Guid id, string userName, string userEmail, string passHash)
        {
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            PasswordHash = passHash;

        }
        public static User Create(Guid id, string userName, string userEmail, string passwordHash)
        {
            return new User(id, userName, userEmail, passwordHash);
        }

    }
}
