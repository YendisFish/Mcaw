using System.Drawing;
using Mcaw.Main.Startup;
using Pastel;

namespace Mcaw.Main.Writers
{
    public class HeaderWriter
    {
        public static async Task Write(SystemInfo inf)
        {
            string header = $"[{inf.Username.Pastel(Color.FromArgb(200, 100, 200))} | {inf.CurrentDirectory.Pastel(Color.FromArgb(20, 150, 150))}] $ > ";
            Console.Write(header);
        }
    }
}