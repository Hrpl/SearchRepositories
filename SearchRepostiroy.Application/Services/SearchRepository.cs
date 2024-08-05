using Microsoft.Extensions.Logging;
using SearchRepository.Domen.Models;
using SearchRepository.Infrastructure;
using SearchRepostiroy.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SearchRepostiroy.Application.Services;

public class SearchRepository : ISearchRepository
{
    protected readonly SearchRepositoryDBContext _dbContext;

    protected readonly ILogger _logger;

    public SearchRepository(SearchRepositoryDBContext dbContext, ILogger logger)
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
            catch (Exception ex)
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
    public async Task<SearchRequest> GetSearchAsync(string subject)
    {
        var search = await _dbContext.SearchRequests.Where(s => s.SearchString == subject).FirstOrDefaultAsync();

        if (search != null)
        {
            _logger.LogInformation($"Получение объекта с запросом {subject}");
            return search;
        }
        else
        {
            _logger.LogError($"Запрос со строкой {subject} не был найден");
            return null;
        }
    }
}
