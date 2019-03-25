using System.Collections.Generic;
using System.Threading.Tasks;
using GithubQuery.Enums;
using GithubQuery.Models;

namespace GithubQuery.Services.Core
{
    public interface IGithubApiService
    {
        Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization);

        Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization, int resultsPerPage);

        Task<IEnumerable<GithubRepository>> GetReposByPageAsync(string organization, int pageNumber, int resultsPerPage);

        Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state);

        Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state, int resultsPerPage);
        
        Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state, int pageNumber, int resultsPerPage);
    }
}