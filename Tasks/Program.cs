using System.Collections.Concurrent;

namespace Tasks
{
    public class Program
    {
        private static object SyncObject = new();
        private static ConcurrentQueue<string> stringsFromText = new ConcurrentQueue<string>();

        static async Task Main(string[] args)
        {
            string path = @"en.txt";
            string path2 = @"ukr.txt";
            string path3 = @"de.txt";
            string path4 = @"fr.txt";
            string path5 = @"ital.txt";

            Task[] tasks = new Task[5]
            {
                // var1
                new Task(async () => await ReadFromFile(path)),
                new Task(async () => await ReadFromFile(path2)),
                new Task(async () => await ReadFromFile(path3)),
                new Task(async () => await ReadFromFile(path4)),
                new Task(async () => await ReadFromFile(path5))
                
                // var 2
                 /*new Task(async () => await ReadFromFileAndPrint(path)),
                 new Task(async () => await ReadFromFileAndPrint(path2)),
                 new Task(async () => await ReadFromFileAndPrint(path3)),
                 new Task(async () => await ReadFromFileAndPrint(path4)),
                 new Task(async () => await ReadFromFileAndPrint(path5))*/
            };

            foreach (var task in tasks)
            {
                task.Start();
            }

            foreach (var task in tasks)
            {
                task.Wait();
            }

            foreach (string str in stringsFromText)
            {
                Console.WriteLine(str);
            }
            
            Console.ReadKey();
        }

        //var 1
        static async Task ReadFromFile(string path)
        {
            try
            {
                var file = File.OpenRead(path);
                using var stream = new StreamReader(file);
                string line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    stringsFromText.Enqueue(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //var 2
        static async Task<string> ReadFromFileAndPrint(string path)
        {
            try
            {
                var file = File.OpenRead(path);
                using var stream = new StreamReader(file);
                string? line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    Monitor.Enter(SyncObject);
                    Console.WriteLine(line);
                    Console.WriteLine("--------------------------");
                    Monitor.Exit(SyncObject);
                }
                return line;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
    }
}