using Microsoft.EntityFrameworkCore;
using SearchRepository.Application.Interface;
using SearchRepository.Domen.Models;
using SearchRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Services;

public class UserRepository : IUserRepository
{

    protected readonly SearchRepositoryDBContext _dbContext;

    public UserRepository(SearchRepositoryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Добавить нового пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);

        try
        {
            _dbContext.SaveChangesAsync();
        }
        catch 
        {
            throw new Exception();
        }
    }

    /// <summary>
    /// Получить нового пользователя
    /// </summary>
    /// <returns></returns>
    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }
}
