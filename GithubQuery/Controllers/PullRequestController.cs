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
        [Route("{organization}/pulls")]
        public IEnumerable<PullRequest> GetAllOrgPullRequests(string organization, State state = State.all)
        {
            return _githubApiFacade.GetAllOrgPullRequests(organization, state);
        }

        [HttpGet]
        [Route("{organization}/pulls/count")]
        public JsonResult GetAllOrgPullRequestsCount(string organization, State state = State.all)
        {
            var result = new
            {
                count = _githubApiFacade.GetAllOrgPullRequests(organization, state).ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls")]
        public IEnumerable<PullRequest> GetAllRepoPullRequests(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            return _githubApiFacade.GetAllRepoPullRequests(organization, repoName, state, resultsPerPage);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/count")]
        public JsonResult GetAllRepoPullRequestsCount(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            var result = new
            {
                count = _githubApiFacade.GetAllRepoPullRequests(organization, repoName, state, resultsPerPage).ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/page/{pageNumber:int}")]
        public IEnumerable<PullRequest> GetRepoPullRequestsByPage(string organization, string repoName, State state = State.all, int pageNumber = 1, int resultsPerPage = 100)
        {
            return _githubApiFacade.GetRepoPullRequestsByPage(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}