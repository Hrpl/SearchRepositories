using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Domen.Models;

public class Repository
{
    public string Name { get; set; }
    public string Autor {  get; set; }
    public int Stargazers { get; set; } 
    public int Watchers { get; set; }
    public string HtmlUrl { get; set; }
    public string Description { get; set; } 
}
