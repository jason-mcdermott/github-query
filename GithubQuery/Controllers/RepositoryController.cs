using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<GithubRepository> GetAllRepos(string organization)
        {
            return _githubApiFacade.GetAllRepos(organization);
        }

        [HttpGet]
        [Route("{organization}/repos/count")]
        public JsonResult GetAllReposCount(string organization)
        {
            var result = new { count = _githubApiFacade.GetAllRepos(organization).ToList().Count };

            return Json(result);
        }

        [HttpGet]
        [Route("{organization}/repos/page/{pageNumber:int}")]
        public IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber = 1, int resultsPerPage = 100)
        {
            return _githubApiFacade.GetReposByPage(organization, pageNumber, resultsPerPage);
        }
    }
}