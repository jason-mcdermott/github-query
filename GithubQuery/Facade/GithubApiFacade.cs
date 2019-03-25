using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, DateTime start, DateTime end, string filterBy, State state, int resultsPerPage)
        {
            var filter = CreateFilter(filterBy, start, end);

            var pullRequests = await _githubApiService.GetAllRepoPullRequestsAsync(organization, repoName, state, resultsPerPage);
            
            return pullRequests.Where(filter);
        }

        public async Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            return await _githubApiService.GetRepoPullRequestsByPageAsync(organization, repoName, state, pageNumber, resultsPerPage);
        }

        private Func<PullRequest, bool> CreateFilter(string filterBy, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(filterBy) || start == DateTime.MinValue || end == DateTime.MinValue)
            {
                // no filtering
                return new Func<PullRequest, bool>(x => true);
            }
            else if (filterBy.ToLowerInvariant().Equals("updated_at"))
            {
                return new Func<PullRequest, bool>(x => x.UpdatedAt > start && x.UpdatedAt < end);
            }
            else if (filterBy.ToLowerInvariant().Equals("created_at"))
            {
                return new Func<PullRequest, bool>(x => x.CreatedAt > start && x.CreatedAt < end);
            }
            else if (filterBy.ToLowerInvariant().Equals("closed_at"))
            {
                return new Func<PullRequest, bool>(x => x.ClosedAt > start && x.ClosedAt < end);
            }
            else if (filterBy.ToLowerInvariant().Equals("merged_at"))
            {
                return new Func<PullRequest, bool>(x => x.MergedAt > start && x.MergedAt < end);
            }
            else
            {
                // no filtering
                return new Func<PullRequest, bool>(x => true);
            }
        }
    }
}