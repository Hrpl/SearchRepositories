using SearchRepository.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
