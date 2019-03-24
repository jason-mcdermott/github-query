using System.Collections.Generic;
using System.Linq;
using GithubQuery.Enums;
using GithubQuery.Facade.Core;
using GithubQuery.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubQuery.Controllers
{
    [Route("api")]
    public class PullRequestController : Controller
    {
        private readonly IGithubApiFacade _githubApiFacade;

        public PullRequestController(IGithubApiFacade githubApiFacade)
        {
            _githubApiFacade = githubApiFacade;
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls")]
        public IEnumerable<PullRequest> GetAllPullRequests(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            return _githubApiFacade.GetAllPullRequests(organization, repoName, state, resultsPerPage);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/count")]
        public JsonResult GetAllPullRequestsCount(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            var result = new
            {
                count = _githubApiFacade.GetAllPullRequests(organization, repoName, state, resultsPerPage).ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/page/{pageNumber:int}")]
        public IEnumerable<PullRequest> GetPullRequestsByPage(string organization, string repoName, State state = State.all, int pageNumber = 1, int resultsPerPage = 100)
        {
            return _githubApiFacade.GetPullRequestsByPage(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}