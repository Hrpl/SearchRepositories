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
    public async Task<User> Login(string login, string password)
    {
        var response = await _dbContext.Users.Where(u => u.Name == login && u.Password == password).FirstOrDefaultAsync();
        return response; 
    }
}
