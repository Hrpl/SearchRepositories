using SearchRepository.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Interface;

public interface ILoginServices
{
    public Task<User> Login(string login);
}
