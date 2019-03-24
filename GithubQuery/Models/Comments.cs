using Newtonsoft.Json;

namespace GithubQuery.Models
{
    public class Comments
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}