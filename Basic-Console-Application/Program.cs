//https:\//learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-teleprompter
namespace TeleprompterConsole;

internal class Program
{
    static string filepath = "/Users/ibukunoluwaakintobi/Documents/sampleQuotes.txt";
    //static void Main(string[] args)
    static async Task Main(string[] args)
    {
        // in this code, we are synchronously waiting for the task to complete 
        //var lines = ReadFrom(filepath);
        //foreach (var line in lines)
        //{
        //    Console.WriteLine(line);
        //    if(!string.IsNullOrWhiteSpace(line))
        //    {
        //        var pause = Task.Delay(200);
        //        //Synchronously waiting for a task to complete execution, 
        //        //this is an anti-pattern
        //        pause.Wait();
        //    }
        //}
        // here , because we are using the await keyword, the Main method is async ,
        //so it is done asynchronously
        //await ShowTeleprompter();
        await RunTelemprompter();
    }

    static IEnumerable<string> ReadFrom(string file)
    {
        string? line;
        using (var reader = File.OpenText(filepath))
        {
            while((line = reader.ReadLine()) != null)
            //The object returned by the ReadFrom method contains the code to generate each item in the sequence
            // here, this involves reading one line from the text file and returning it 
            {
                //yield return line;
                var words = line.Split(' ');
                var lineLength = 0;
                foreach (var word in words)
                {
                    yield return word + " ";
                    lineLength += word.Length + 1;
                    if(lineLength > 70)
                    {
                        yield return Environment.NewLine;
                        lineLength = 0;
                    }
                }
                yield return Environment.NewLine;
            }
        }
    }


    //We are not using Wait() to wait for a task to synchronously finish 
    private static async Task ShowTeleprompter(TeleprompterConfig config)
    {
        var words = ReadFrom(filepath);
        foreach (var word in words)
        {
            Console.Write(word);
            if(!string.IsNullOrWhiteSpace(word))
            {
                await Task.Delay(200);
            }
        }
        config.SetDone();
    }


    // This method waits to accept input from the accept from the console
    // it reads a key from the console and modifies the varibale representing the delay ,'<' or '>'
    // or finishes when the user presses 'X' or 'x
    private static async Task GetInput(TeleprompterConfig config)
    {
        var delay = 200;
        Action work = () =>
        {
            do
            {
                var key = Console.ReadKey(true);
                if (key.KeyChar == '>')
                {
                    delay -= 10;
                }
                else if (key.KeyChar == '<')
                {
                    delay += 10;
                }
                else if (key.KeyChar == 'X' || key.KeyChar == 'x')
                {
                    break;
                }

            } while (true);
        };
        // Run queues the specific task to be run on the thread pool
        await Task.Run(work);
    }
    private static async Task RunTelemprompter()
    {
        var config = new TeleprompterConfig();
        var displayTask = ShowTeleprompter(config);

        var speedTask = GetInput(config);
        await Task.WhenAny(displayTask, speedTask);
    }

}