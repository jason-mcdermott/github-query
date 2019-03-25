using System;
using System.Collections.Generic;
using GithubQuery.Enums;
using GithubQuery.Models;

namespace GithubQuery.Facade.Core
{
    public interface IGithubApiFacade
    {
        IEnumerable<GithubRepository> GetAllRepos(string organization);
       
        IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage);

        IEnumerable<PullRequest> GetAllOrgPullRequests(string organization, State state);

        IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, State state, int resultsPerPage);

        IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, DateTime start, DateTime end, string filter, State state, int resultsPerPage);

        IEnumerable<PullRequest> GetRepoPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage);
    }
}