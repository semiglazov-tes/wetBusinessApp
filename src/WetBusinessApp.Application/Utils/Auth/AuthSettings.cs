namespace WetBusinessApp.Application.Utils.Auth
{
    public record AuthSettings
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; }
    }
}
