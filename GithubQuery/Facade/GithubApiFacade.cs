using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubQuery.Enums;
using GithubQuery.Facade.Core;
using GithubQuery.Models;
using GithubQuery.Services.Core;

namespace GithubQuery.Facade
{
    public class GithubApiFacade : IGithubApiFacade
    {
        private readonly IGithubApiService _githubApiService;

        public GithubApiFacade(IGithubApiService githubApiService)
        {
            _githubApiService = githubApiService;
        }
        
        public async Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization)
        {
            return await _githubApiService.GetAllReposAsync(organization);
        }

        public async Task<IEnumerable<GithubRepository>> GetReposByPageAsync(string organization, int pageNumber, int resultsPerPage)
        {
            return await _githubApiService.GetReposByPageAsync(organization, pageNumber, resultsPerPage);
        }

        public async Task<IEnumerable<PullRequest>> GetAllOrgPullRequestsAsync(string organization, State state)
        {
            var pullrequests = new List<PullRequest>();

            var repos = await _githubApiService.GetAllReposAsync(organization);

            foreach (var repo in repos)
            {
                var pulls = await _githubApiService.GetAllRepoPullRequestsAsync(organization, repo.Name, state);
                pullrequests.AddRange(pulls);
            }

            return pullrequests;
        }

        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state, int resultsPerPage)
        {
            return await _githubApiService.GetAllRepoPullRequestsAsync(organization, repoName, state, resultsPerPage);
        }

        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, DateTime start, DateTime end, string filter, State state, int resultsPerPage)
        {
            // perhap pass the 'filter' to a 'FilterFactory' that can return the correct Fun<T, bool>?
            var condition = new Func<PullRequest, bool>(x => x.UpdatedAt > start && x.UpdatedAt < end);

            var pullRequests = await _githubApiService.GetAllRepoPullRequestsAsync(organization, repoName, state, resultsPerPage);
            
            return pullRequests.Where(condition);
        }

        public async Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            return await _githubApiService.GetRepoPullRequestsByPageAsync(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}