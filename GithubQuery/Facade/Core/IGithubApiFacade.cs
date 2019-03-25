using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GithubQuery.Enums;
using GithubQuery.Models;

namespace GithubQuery.Facade.Core
{
    public interface IGithubApiFacade
    {
        Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization);

        Task<IEnumerable<GithubRepository>> GetReposByPageAsync(string organization, int pageNumber, int resultsPerPage);

        Task<IEnumerable<PullRequest>> GetAllOrgPullRequestsAsync(string organization, State state);

        Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state, int resultsPerPage);

        Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, DateTime start, DateTime end, string filterBy, State state, int resultsPerPage);

        Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state, int pageNumber, int resultsPerPage);
    }
}