using Newtonsoft.Json;

namespace GithubQuery.Models
{
    public class Base
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("repo")]
        public UserRepository Repo { get; set; }
    }
}