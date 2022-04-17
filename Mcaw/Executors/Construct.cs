namespace Mcaw.Main.Executors
{
    public class Construct
    {
        public static async Task<List<string>> ConstructProgramArgs(string input)
        {
            List<string> ret = new();
            string[] array = input.Split(" ");
            
            ret.Add(array[0]);

            string toadd = "";
            for (int i = 1; i < array.Length; i++)
            {
                toadd = toadd + " " + array[i];
            }
            
            ret.Add(toadd.Trim());

            return ret;
        }
    }
}