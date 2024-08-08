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
    public async Task DeleteSearchAsync(string subject)
    {
        var request = await _dbContext.SearchRequests.Where(s => s.SearchString == subject).FirstOrDefaultAsync();
        if (request != null)
        {
            _dbContext.SearchRequests.Remove(request);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Удаление запроса со строкой {subject}");
            }
            catch 
            {
                _logger.LogError($"Ошибка удаление запроса {subject}");
                throw new Exception();
            }
        }
        else
        {
            _logger.LogError($"Нет строки {subject} в базе данных");
            throw new Exception();
        }
    }


    /// <summary>
    /// Получить запрос по строке запроса
    /// </summary>
    /// <param name="subject"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Repository>> GetSearchAsync(string subject)
    {
        
        string? jsonString = "";

        var request  = await _dbContext.SearchRequests.Where(s => s.SearchString == subject).FirstOrDefaultAsync();
        
        if (request == null)
        {
            _logger.LogError($"Запрос со строкой {subject} не был найден в хранилище. ");
            _logger.LogInformation("Производится запрос в API GitHub");

            jsonString = await GitHubClient.GetGitHubRepository(subject);

            // если выбросит исключение, то контроллер отловит его
            await AddSearchAsync(new SearchRequest()
            {
                SearchString = subject,
                JsonResponse = jsonString
            });
        }
        else
        {
            _logger.LogInformation($"Запрос {subject} получен из локального хранилища");
            jsonString = request.JsonResponse;
        }

        return ParseToJson.Parse(jsonString);
    }
}
