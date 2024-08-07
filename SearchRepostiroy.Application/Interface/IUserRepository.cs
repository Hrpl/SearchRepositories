using SearchRepository.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Interface;

public interface IUserRepository
{
    public Task<List<User>> GetUsers();

    public Task AddUser(User user);
}
