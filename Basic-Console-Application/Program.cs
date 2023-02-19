//https:\//learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-teleprompter
namespace TeleprompterConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var lines = ReadFrom("sampleQuotes.txt");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            if(!string.IsNullOrWhiteSpace(line))
            {
                var pause = Task.Delay(200);
                //Synchronously waiting for a task to complete execution, 
                //this is an anti-pattern
                pause.Wait();
            }
        }
    }
    static IEnumerable<string> ReadFrom(string file)
    {
        string? line;
        using (var reader = File.OpenText("/Users/ibukunoluwaakintobi/Documents/sampleQuotes.txt"))
        {
            while((line = reader.ReadLine()) != null)
            //The object returned by the ReadFrom method contains the code to generate each item in the sequence
            // here, this involcves reading one line from the text file and returning it 
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
}