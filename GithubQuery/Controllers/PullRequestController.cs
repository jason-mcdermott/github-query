using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<PullRequest>> GetAllOrgPullRequestsAsync(string organization, State state = State.all)
        {
            return await _githubApiFacade.GetAllOrgPullRequestsAsync(organization, state);
        }

        [HttpGet]
        [Route("{organization}/pulls/count")]
        public async Task<JsonResult> GetAllOrgPullRequestsCountAsync(string organization, State state = State.all)
        {
            var pulls = await _githubApiFacade.GetAllOrgPullRequestsAsync(organization, state);

            var result = new
            {
                count = pulls.ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls")]
        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            return await _githubApiFacade.GetAllRepoPullRequestsAsync(organization, repoName, state, resultsPerPage);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/count")]
        public async Task<JsonResult> GetAllRepoPullRequestsCountAsync(string organization, string repoName, State state = State.all, int resultsPerPage = 100)
        {
            var pulls = await _githubApiFacade.GetAllRepoPullRequestsAsync(organization, repoName, state, resultsPerPage);

            var result = new
            {
                count = pulls.ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/daterange")]
        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsDateRangeAsync(string organization, string repoName, DateTime start, DateTime end, string filter, State state = State.all, int resultsPerPage = 100)
        {
            return await _githubApiFacade.GetAllRepoPullRequestsAsync(organization, repoName, start, end, filter, state, resultsPerPage);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/daterange/count")]
        public async Task<JsonResult> GetAllRepoPullRequestsDateCountAsync(string organization, string repoName, DateTime start, DateTime end, string filter, State state = State.all, int resultsPerPage = 100)
        {
            var pulls = await _githubApiFacade.GetAllRepoPullRequestsAsync(organization, repoName, start, end, filter, state, resultsPerPage);

            var result = new
            {
                count = pulls.ToList().Count
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/{repoName}/pulls/page/{pageNumber:int}")]
        public async Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state = State.all, int pageNumber = 1, int resultsPerPage = 100)
        {
            return await _githubApiFacade.GetRepoPullRequestsByPageAsync(organization, repoName, state, pageNumber, resultsPerPage);
        }
    }
}