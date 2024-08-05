using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchRepository.Domen.Models;
namespace SearchRepository.Application.Interface;

public interface ISearchRepository
{
    public Task<List<Repository>> GetSearchAsync(string subject);

    public Task AddSearchAsync(SearchRequest searchRequest);

    public Task DeleteSearchAsync(string subject);
}
