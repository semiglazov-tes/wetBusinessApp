
namespace WetBusinessApp.Domain
{
    public class User
    {
        public uint Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public User(string userName, string passHash)
        {
            UserName = userName;
            PasswordHash = passHash;
        }

    }
}
