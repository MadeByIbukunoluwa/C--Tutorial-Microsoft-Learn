using System.Text.Json.Serialization;
//public record class Repository(string name);


//public record class Repository([property:JsonPropertyName("name")] string Name);

public record class Repository(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("html_url")] Uri GithubHomeUrl,
    [property: JsonPropertyName("homepage")] string Homepage,
    [property: JsonPropertyName("watchers")] int Watchers,
    [property: JsonPropertyName("pushed_at")] DateTime LastPushUtc)
 
{
    public DateTime LastPush => LastPushUtc.ToLocalTime();
}
