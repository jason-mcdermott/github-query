using System.Collections.Generic;
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

        public IEnumerable<GithubRepository> GetAllRepos(string organization, int resultsPerPage)
        {
            return _githubApiService.GetAllRepos(organization, resultsPerPage);
        }

        public IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage)
        {
            return _githubApiService.GetReposByPage(organization, pageNumber, resultsPerPage);
        }

        public IEnumerable<PullRequest> GetAllPullRequests(string organization, string repoName, State state, int resultsPerPage)
        {
            return _githubApiService.GetAllPullRequests(organization, repoName, state, resultsPerPage);
        }

        public IEnumerable<PullRequest> GetPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            return _githubApiService.GetPullRequestsByPage(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}