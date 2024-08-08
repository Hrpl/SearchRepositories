using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Application.Interface;

public interface IGitHubClient
{
    public static abstract Task<string> GetGitHubRepository(string subject);
}
