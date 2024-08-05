using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchRepository.Domen.Models;
namespace SearchRepostiroy.Application.Interface;

internal interface ISearchRepository
{
    public Task<SearchRequest> GetSearchAsync(string subject);

    public Task AddSearchAsync(SearchRequest searchRequest);

    public Task DeleteSearchAsync(string subject);
}
