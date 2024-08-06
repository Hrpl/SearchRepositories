using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SearchRepository.Domen.Models;
using SearchRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchRepository.Application.Interface;

namespace SearchRepository.Application.Services;

public class LoginServices : ILoginServices
{
    protected readonly SearchRepositoryDBContext _dbContext;

    protected readonly ILogger<LoginServices> _logger;

    public LoginServices(SearchRepositoryDBContext dbContext, ILogger<LoginServices> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Метод для авторизации
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public async Task<User> Login(string login)
    {
        var response = await _dbContext.Users.Where(u => u.Name == login).FirstOrDefaultAsync();
        return response; 
    }
}
