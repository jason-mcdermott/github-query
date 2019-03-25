using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubQuery.Facade.Core;
using GithubQuery.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubQuery.Controllers
{
    [Route("api")]
    public class RepositoryController : Controller
    {
        private readonly IGithubApiFacade _githubApiFacade;

        public RepositoryController(IGithubApiFacade githubApiFacade)
        {
            _githubApiFacade = githubApiFacade;
        }
        
        [HttpGet]
        [Route("{organization}/repos")]
        public async Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization)
        {
            return await _githubApiFacade.GetAllReposAsync(organization);
        }

        [HttpGet]
        [Route("{organization}/repos/count")]
        public async Task<JsonResult> GetAllReposCount(string organization)
        {
            var repos = await _githubApiFacade.GetAllReposAsync(organization);

            var result = new { count = repos.ToList().Count };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/repos/page/{pageNumber:int}")]
        public async Task<IEnumerable<GithubRepository>> GetReposByPageAsync(string organization, int pageNumber = 1, int resultsPerPage = 100)
        {
            return await _githubApiFacade.GetReposByPageAsync(organization, pageNumber, resultsPerPage);
        }
    }
}