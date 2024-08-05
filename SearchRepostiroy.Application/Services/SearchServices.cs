using Microsoft.Extensions.Logging;
using SearchRepository.Domen.Models;
using SearchRepository.Infrastructure;
using SearchRepository.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchRepository.Application.Services;

public class SearchServices : ISearchRepository
{
    protected readonly SearchRepositoryDBContext _dbContext;

    protected readonly ILogger<SearchServices> _logger;

    public SearchServices(SearchRepositoryDBContext dbContext, ILogger<SearchServices> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Добавить запрос в базу данных
    /// </summary>
    /// <param name="searchRequest"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddSearchAsync(SearchRequest searchRequest)
    {
        if (searchRequest.SearchString != "")
        {
            await _dbContext.AddAsync(searchRequest);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Запрос успешно добавлен");
            }
            catch
            {
                _logger.LogError($"Произошла ошибка добавления");
                throw new Exception();
            }
        }
        else throw new Exception();
    }

    /// <summary>
    /// Удалить запрос по строке запроса
    /// </summary>
    /// <param name="subject"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task DeleteSearchAsync(string subject)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Получить запрос по строке запроса
    /// </summary>
    /// <param name="subject"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Repository>> GetSearchAsync(string subject)
    {
        List<Repository> response = new List<Repository>();
        string? jsonString = "";

        var request  = await _dbContext.SearchRequests.Where(s => s.SearchString == subject).FirstOrDefaultAsync();
        
        if (request == null)
        {
            _logger.LogError($"Запрос со строкой {subject} не был найден в хранилище. ");
            _logger.LogInformation("Производится запрос в API GitHub");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "YourAppName/1.0");

            jsonString = await httpClient.GetStringAsync($"https://api.github.com/search/repositories?q={subject}");

            //тут надо сохранить объект в бд


            var responseMessage = await httpClient.PutAsJsonAsync("http://localhost:5080/api/find", new SearchRequest()
            {
                SearchString = subject,
                JsonResponse = jsonString
            });

            if (responseMessage.IsSuccessStatusCode == false)
            {
                _logger.LogError("Произошла ошибка при сохранении нового запроса");
                throw new Exception();
            }
        }
        else
        {
            _logger.LogInformation($"Запрос {subject} получен из локального хранилища");
            jsonString = request.JsonResponse;
        }

        var jsonResponse = JObject.Parse(jsonString);
        var jsonItem = jsonResponse["items"];

        foreach ( var item in jsonItem) {
            response.Add(new Repository
            {
                Name = item["name"].ToString(),
                Autor = item["owner"]["login"].ToString(),
                Stargazers = item["stargazers_count"].Value<int>(),
                Watchers = item["watchers_count"].Value<int>(),
                HtmlUrl = item["html_url"].ToString()
            });
        }

        return response;
    }
}
