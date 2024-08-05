using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchRepository.Application.Interface;
using SearchRepository.Domen.Models;

namespace SearchRepository.API.Controllers;

[Route("api/find/")]
[ApiController]
public class SearchController : ControllerBase
{
    protected readonly ISearchRepository _searchRepository;

    public SearchController(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository;
    }

    [HttpPost]
    public async Task<ActionResult<SearchRequest>> GetSearchRequest([FromBody] string subject) {
        try
        {
            var search = await _searchRepository.GetSearchAsync(subject);
            if (search != null) return Ok(search);
            else return BadRequest();
        }
        catch (Exception ex)
        {
            return Problem("Ошибка во время сохранения");
        }
    }

    [HttpPut]
    public async Task<ActionResult> AddSearchRequest([FromBody] SearchRequest searchRequest)
    {
        try
        {
            await _searchRepository.AddSearchAsync(searchRequest);
            return Created();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{request}")]
    public async Task<ActionResult> DeleteSearchRequest([FromRoute] string request)
    {
        try
        {
            await _searchRepository.DeleteSearchAsync(request);
            return NoContent();
        }
        catch
        {
            return BadRequest();
        }
    }
}
