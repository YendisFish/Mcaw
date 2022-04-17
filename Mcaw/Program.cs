using System.Diagnostics;
using Mcaw.Main.Executors;
using Mcaw.Main.Startup;

namespace Mcaw.Main
{
    internal class EntryPoint
    {
        public static SystemInfo inf = new SystemInfo();
        
        public static async Task Main()
        {

            // Clear window for shell (adds good boi effect)
            Process.Start("clear");

            while (true)
            {
                await Sequence();
            }
        }

        private static async Task Sequence()
        {
            await Writers.HeaderWriter.Write(inf);
            string? input = Console.ReadLine() ?? null;

            try
            {
                TaskOut outp = await Executors.ExecutorLib.SafeExecute(input.Trim());
                Console.WriteLine(outp.output);

                inf.CurrentDirectory = outp.currentdir;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not execute!");
                //Maybe add better logic here
            }
        }
    }

}