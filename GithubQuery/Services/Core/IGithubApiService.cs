using System;
using System.Collections.Generic;
using GithubQuery.Enums;
using GithubQuery.Models;

namespace GithubQuery.Services.Core
{
    public interface IGithubApiService
    {
        IEnumerable<GithubRepository> GetAllRepos(string organization);

        IEnumerable<GithubRepository> GetAllRepos(string organization, int resultsPerPage);
        
        IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage);

        IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, State state);

        IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, State state, int resultsPerPage);
        
        IEnumerable<PullRequest> GetRepoPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage);
    }
}