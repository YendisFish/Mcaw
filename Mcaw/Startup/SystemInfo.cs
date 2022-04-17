namespace Mcaw.Main.Startup
{
    public class SystemInfo
    {
        public string Username { get; set; }
        public string CurrentDirectory { get; set; }

        public SystemInfo()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            Username = Environment.UserName;
        }
        
    }
}