using System.Collections.Generic;
using GithubQuery.Enums;
using GithubQuery.Models;

namespace GithubQuery.Services.Core
{
    public interface IGithubApiService
    {
        IEnumerable<GithubRepository> GetAllRepos(string organization, int resultsPerPage);

        IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage);

        IEnumerable<PullRequest> GetAllPullRequests(string organization, string repoName, State state, int resultsPerPage);

        IEnumerable<PullRequest> GetPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage);
    }
}