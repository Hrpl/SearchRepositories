using Microsoft.Extensions.Logging;
using SearchRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Services;

public class LoginServices
{
    protected readonly SearchRepositoryDBContext _dbContext;

    protected readonly ILogger<LoginServices> _logger;

    public LoginServices(SearchRepositoryDBContext dbContext, ILogger<LoginServices> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Login(string login)
    {
    }
}
