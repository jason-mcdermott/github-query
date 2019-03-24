using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using GithubQuery.Enums;
using GithubQuery.Extensions;
using GithubQuery.Models;
using GithubQuery.Services.Core;
using Newtonsoft.Json;

namespace GithubQuery.Services
{
    public class GithubApiService : IGithubApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl = "https://api.github.com";
        
        public GithubApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GithubQuery");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<GithubRepository> GetAllRepos(string organization, int resultsPerPage)
        {
            var results = new List<GithubRepository>();
            var parsedHeader = new LinkHeader();
            var url = $"{_remoteServiceBaseUrl}/orgs/{organization}/repos?page=1&per_page={resultsPerPage}";

            do
            {
                var response = _httpClient.GetAsync(url);
                var linkHeader = new List<string>().AsEnumerable();
                response.Result.Headers.TryGetValues("Link", out linkHeader);
                parsedHeader = linkHeader?.First().FromHeader();

                if (response.Result.IsSuccessStatusCode)
                {
                    results.AddRange(JsonConvert.DeserializeObject<List<OrganizationRepository>>(response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
                    url = parsedHeader?.NextLink;
                }
                
            } while (parsedHeader?.NextLink != null);
            
            return results;
        }

        public IEnumerable<GithubRepository> GetReposByPage(string organization, int pageNumber, int resultsPerPage)
        {
            var results = new List<OrganizationRepository>();
            var response = _httpClient.GetAsync($"{_remoteServiceBaseUrl}/orgs/{organization}/repos?page={pageNumber}&per_page={resultsPerPage}");

            if (response.Result.IsSuccessStatusCode)
            {
                results.AddRange(JsonConvert.DeserializeObject<List<OrganizationRepository>>(response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
            }

            return results;
        }


        public IEnumerable<PullRequest> GetAllPullRequests(string organization, string repoName, State state, int resultsPerPage)
        {
            var results = new List<PullRequest>();
            var parsedHeader = new LinkHeader();
            var url = $"{_remoteServiceBaseUrl}/repos/{organization}/{repoName}/pulls?state={state}&page=1&per_page={resultsPerPage}";

            do
            {
                var response = _httpClient.GetAsync(url);
                var linkHeader = new List<string>().AsEnumerable();
                response.Result.Headers.TryGetValues("Link", out linkHeader);
                parsedHeader = linkHeader?.First().FromHeader();
                
                if (response.Result.IsSuccessStatusCode)
                {
                    results.AddRange(JsonConvert.DeserializeObject<List<PullRequest>>(response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
                    url = parsedHeader?.NextLink;
                }

            } while (parsedHeader?.NextLink != null);

            return results;
        }

        public IEnumerable<PullRequest> GetPullRequestsByPage(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            var results = new List<PullRequest>();
            var response = _httpClient.GetAsync($"{_remoteServiceBaseUrl}/repos/{organization}/{repoName}/pulls?state={state}&page={pageNumber}&per_page={resultsPerPage}");

            if (response.Result.IsSuccessStatusCode)
            {
                results.AddRange(JsonConvert.DeserializeObject<List<PullRequest>>(response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
            }

            return results;
        }
    }
}