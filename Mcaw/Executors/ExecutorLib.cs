using System.Diagnostics;

namespace Mcaw.Main.Executors
{
    public class ExecutorLib
    {
        public static async Task<TaskOut> BasicExecutor(string input, int token = 10000)
        {
            List<string> inp = await Construct.ConstructProgramArgs(input);
            
            ProcessStartInfo inf = new();
            inf.FileName = inp[0];

            if (inp.Count > 1)
            {
                inf.Arguments = inp[1];
            }
            
            inf.RedirectStandardOutput = true;
            
            Process? proc = Process.Start(inf);
            
            CancellationTokenSource tsource = new();
            tsource.CancelAfter(token);

            await proc.WaitForExitAsync(tsource.Token);

            return new TaskOut(proc.StandardOutput.ReadToEnd(), Directory.GetCurrentDirectory());
        }

        public static async Task<TaskOut> SafeExecute(string input)
        {
            if (input.Contains("cd"))
            {
                List<string> cmd = await Construct.ConstructProgramArgs(input);

                if (cmd[1] == "~" || cmd[1] == "" || cmd[1] == null)
                {
                    cmd[1] = "/home/" + Environment.UserName + "/";
                }

                Directory.SetCurrentDirectory(cmd[1]);

                return new TaskOut("Changed!", Directory.GetCurrentDirectory());
            }

            if (input.Contains("pacman"))
            {
                return await BasicExecutor(input, 10000000);
            }

            if (input.Contains("cls"))
            {
                return await BasicExecutor("clear");
            }

            return await BasicExecutor(input);
        }
    }
}