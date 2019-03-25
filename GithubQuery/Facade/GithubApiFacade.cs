using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<GithubRepository> GetAllRepos(string organization)
        {
            return _githubApiService.GetAllRepos(organization);
        }
        
        public IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage)
        {
            return _githubApiService.GetReposByPage(organization, pageNumber, resultsPerPage);
        }

        public IEnumerable<PullRequest> GetAllOrgPullRequests(string organization, State state)
        {
            var pullrequests = new List<PullRequest>();

            var repos = _githubApiService.GetAllRepos(organization);

            foreach (var repo in repos)
            {
                pullrequests.AddRange(_githubApiService.GetAllRepoPullRequests(organization, repo.Name, state));
            }

            return pullrequests;
        }

        public IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, State state, int resultsPerPage)
        {
            return _githubApiService.GetAllRepoPullRequests(organization, repoName, state, resultsPerPage);
        }

        public IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, DateTime start, DateTime end, string filter, State state, int resultsPerPage)
        {
            // perhap pass the 'filter' to a 'FilterFactory' that can return the correct Fun<T, bool>?
            var condition = new Func<PullRequest, bool>(x => x.UpdatedAt > start && x.UpdatedAt < end);

            var pullRequests = _githubApiService.GetAllRepoPullRequests(organization, repoName, state, resultsPerPage);
            
            return pullRequests.Where(condition);
        }

        public IEnumerable<PullRequest> GetRepoPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            return _githubApiService.GetRepoPullRequestsByPage(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}