﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GithubQuery.Enums;
using GithubQuery.Extensions;
using GithubQuery.Models;
using GithubQuery.Services.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GithubQuery.Services
{
    public class GithubApiService : IGithubApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _remoteServiceBaseUrl = "https://api.github.com";
        
        public GithubApiService(HttpClient httpClient, IMemoryCache cacheProvider, IConfiguration configuration)
        {
            _cache = cacheProvider;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GithubQuery");
            
            string accessToken = configuration["accessToken"];

            if (!string.IsNullOrEmpty(accessToken))
            {
                // use access token if you got one
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization, int resultsPerPage)
        {
            string cacheKey = $"repos|{organization}|{resultsPerPage}";
            var cachedResponse = _cache.Get<List<OrganizationRepository>>(cacheKey);

            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            var results = new List<OrganizationRepository>();
            var parsedHeader = new LinkHeader();
            var url = $"{_remoteServiceBaseUrl}/orgs/{organization}/repos?page=1&per_page={resultsPerPage}";

            do
            {
                var response = await _httpClient.GetAsync(url);
                var linkHeader = new List<string>().AsEnumerable();
                response.Headers.TryGetValues("Link", out linkHeader);
                parsedHeader = linkHeader?.First().FromHeader();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    results.AddRange(JsonConvert.DeserializeObject<List<OrganizationRepository>>(data));
                    url = parsedHeader?.NextLink;
                }

            } while (parsedHeader?.NextLink != null);

            _cache.Set(cacheKey, results, DateTimeOffset.Now.AddHours(1));

            return results;
        }

        public async Task<IEnumerable<GithubRepository>> GetAllReposAsync(string organization)
        {
            return await GetAllReposAsync(organization, 100);
        }

        public async Task<IEnumerable<GithubRepository>> GetReposByPageAsync(string organization, int pageNumber, int resultsPerPage)
        {
            string cacheKey = $"repos|{organization}|{pageNumber}|{resultsPerPage}";
            var cachedResponse = _cache.Get<List<OrganizationRepository>>(cacheKey);

            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            var results = new List<OrganizationRepository>();
            var response = await _httpClient.GetAsync($"{_remoteServiceBaseUrl}/orgs/{organization}/repos?page={pageNumber}&per_page={resultsPerPage}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                results.AddRange(JsonConvert.DeserializeObject<List<OrganizationRepository>>(data));
            }

            _cache.Set(cacheKey, results, DateTimeOffset.Now.AddHours(1));

            return results;
        }

        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state)
        {
            return await GetAllRepoPullRequestsAsync(organization, repoName, state, 100);
        }

        public async Task<IEnumerable<PullRequest>> GetAllRepoPullRequestsAsync(string organization, string repoName, State state, int resultsPerPage)
        {
            string cacheKey = $"pulls|{organization}|{repoName}|{state}|{resultsPerPage}";
            var cachedResponse = _cache.Get<List<PullRequest>>(cacheKey);

            if (cachedResponse != null)
            {
                return cachedResponse;
            }
            
            var results = new List<PullRequest>();
            var parsedHeader = new LinkHeader();
            var url = $"{_remoteServiceBaseUrl}/repos/{organization}/{repoName}/pulls?state={state}&page=1&per_page={resultsPerPage}";

            do
            {
                var response = await _httpClient.GetAsync(url);
                var linkHeader = new List<string>().AsEnumerable();
                response.Headers.TryGetValues("Link", out linkHeader);
                parsedHeader = linkHeader?.First().FromHeader();
                
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    results.AddRange(JsonConvert.DeserializeObject<List<PullRequest>>(data));
                    url = parsedHeader?.NextLink;
                }

            } while (parsedHeader?.NextLink != null);

            _cache.Set(cacheKey, results, DateTimeOffset.Now.AddHours(1));

            return results;
        }
        
        public async Task<IEnumerable<PullRequest>> GetRepoPullRequestsByPageAsync(string organization, string repoName, State state, int pageNumber, int resultsPerPage)
        {
            string cacheKey = $"pulls|{organization}|{repoName}|{state}|{pageNumber}|{resultsPerPage}";
            var cachedResponse = _cache.Get<List<PullRequest>>(cacheKey);

            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            var results = new List<PullRequest>();
            var response = await _httpClient.GetAsync($"{_remoteServiceBaseUrl}/repos/{organization}/{repoName}/pulls?state={state}&page={pageNumber}&per_page={resultsPerPage}");
            
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                results.AddRange(JsonConvert.DeserializeObject<List<PullRequest>>(data));
            }

            _cache.Set(cacheKey, results, DateTimeOffset.Now.AddHours(1));

            return results;
        }
    }
}