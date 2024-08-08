using Newtonsoft.Json.Linq;
using SearchRepository.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Services;

public class ParseToJson
{
    public static List<Repository> Parse(string jsonString)
    {
        List<Repository> response = new List<Repository>();

        var jsonResponse = JObject.Parse(jsonString);
        var jsonItem = jsonResponse["items"];

        foreach (var item in jsonItem)
        {
            response.Add(new Repository
            {
                Name = item["name"].ToString(),
                Autor = item["owner"]["login"].ToString(),
                Stargazers = item["stargazers_count"].Value<int>(),
                Watchers = item["watchers_count"].Value<int>(),
                HtmlUrl = item["html_url"].ToString(),
                Description = item["description"].ToString()
            });
        }

        return response;
    }
}
