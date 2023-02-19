//Make HTTP requests in a .NET console app using C#

// Build an app that issues requests to a REST service on github
//The app reads information in JSON format and converts the JSON into C# objects.
//namespace RESTclient;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new ();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.githubv3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET foundation Repository Reporter");

var repositories = await ProcessRepositoriesAsync(client);
//foreach (var repo in repositories)
//    Console.Write(repo.Name);
foreach (var repo in repositories)
{
    Console.WriteLine($"Name:{repo.Name}");
    Console.WriteLine($"HomePage:{repo.Homepage}");
    Console.WriteLine($"Github:{repo.GithubHomeUrl}");
    Console.WriteLine($"Description:{repo.Description}");
    Console.WriteLine($"Watchers:{repo.Watchers:#,0}");
    Console.WriteLine($"Last push:{repo.LastPush}");
    Console.WriteLine();

}


//using HttpClient client = new();




//static async Task ProcessRepositoriesAsync(HttpClient client)
static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
    {
    //var json = await client.GetStringAsync("https:\//api.github.com/orgs/dotnet/repos");
    //Console.Write(json);
        // this one uses a stream instead ofa string as its source 
        await using Stream stream =
        await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
    var repositories =
        await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
    foreach (var repo in repositories ?? Enumerable.Empty<Repository>())
        Console.WriteLine(repo.Name);
    return repositories ?? new();
}

