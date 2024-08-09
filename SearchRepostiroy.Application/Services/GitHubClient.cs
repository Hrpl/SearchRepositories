namespace SearchRepository.Application.Services;

public class GitHubClient : IGitHubClient
{
    public static async Task<string> GetGitHubRepository(string subject)
    {
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "YourAppName/1.0");

        var jsonString = await httpClient.GetStringAsync($"https://api.github.com/search/repositories?q={subject}");

        return jsonString;
    }
}
