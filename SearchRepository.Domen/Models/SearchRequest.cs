using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SearchRepository.Domen.Models;

public class SearchRequest
{
    public int Id { get; set; }

    public string SearchString { get; set; }
    public string JsonResponse {  get; set; } 
}
