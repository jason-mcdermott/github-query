using System;
using Newtonsoft.Json;

namespace GithubQuery.Models
{
    public class OrganizationRepository : GithubRepository
    {
        [JsonProperty("owner")]
        public User Owner { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }
    }

    public class UserRepository : GithubRepository
    {
        [JsonProperty("owner")]
        public User User { get; set; }
    }

    public abstract class GithubRepository
    {   
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
        
        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fork")]
        public bool Fork { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("forks_url")]
        public Uri ForksUrl { get; set; }

        [JsonProperty("keys_url")]
        public Uri KeysUrl { get; set; }

        [JsonProperty("collaborators_url")]
        public Uri CollaboratorsUrl { get; set; }

        [JsonProperty("teams_url")]
        public Uri TeamsUrl { get; set; }

        [JsonProperty("hooks_url")]
        public Uri HooksUrl { get; set; }

        [JsonProperty("issue_events_url")]
        public string IssueEventsUrl { get; set; }

        [JsonProperty("events_url")]
        public Uri EventsUrl { get; set; }

        [JsonProperty("assignees_url")]
        public Uri AssigneesUrl { get; set; }

        [JsonProperty("branches_url")]
        public Uri BranchesUrl { get; set; }

        [JsonProperty("tags_url")]
        public Uri TagsUrl { get; set; }

        [JsonProperty("blobs_url")]
        public Uri BlobsUrl { get; set; }

        [JsonProperty("git_tags_url")]
        public Uri GitTagsUrl { get; set; }

        [JsonProperty("git_refs_url")]
        public Uri GitRefsUrl { get; set; }

        [JsonProperty("trees_url")]
        public Uri TreesUrl { get; set; }

        [JsonProperty("statuses_url")]
        public Uri StatusesUrl { get; set; }

        [JsonProperty("languages_url")]
        public Uri LanguagesUrl { get; set; }

        [JsonProperty("stargazers_url")]
        public Uri StargazersUrl { get; set; }

        [JsonProperty("contributors_url")]
        public Uri ContributorsUrl { get; set; }

        [JsonProperty("subscribers_url")]
        public Uri SubscribersUrl { get; set; }

        [JsonProperty("subscription_url")]
        public Uri SubscriptionUrl { get; set; }

        [JsonProperty("commits_url")]
        public Uri CommitsUrl { get; set; }

        [JsonProperty("git_commits_url")]
        public Uri GitCommitsUrl { get; set; }

        [JsonProperty("comments_url")]
        public Uri CommentsUrl { get; set; }

        [JsonProperty("issue_comment_url")]
        public Uri IssueCommentUrl { get; set; }

        [JsonProperty("contents_url")]
        public Uri ContentsUrl { get; set; }

        [JsonProperty("compare_url")]
        public Uri CompareUrl { get; set; }

        [JsonProperty("merges_url")]
        public Uri MergesUrl { get; set; }

        [JsonProperty("archive_url")]
        public Uri ArchiveUrl { get; set; }

        [JsonProperty("downloads_url")]
        public Uri DownloadsUrl { get; set; }

        [JsonProperty("issues_url")]
        public Uri IssuesUrl { get; set; }

        [JsonProperty("pulls_url")]
        public Uri PullsUrl { get; set; }

        [JsonProperty("milestones_url")]
        public Uri MilestonesUrl { get; set; }

        [JsonProperty("notifications_url")]
        public Uri NotificationsUrl { get; set; }

        [JsonProperty("labels_url")]
        public Uri LabelsUrl { get; set; }

        [JsonProperty("releases_url")]
        public Uri ReleasesUrl { get; set; }

        [JsonProperty("deployments_url")]
        public Uri DeploymentsUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("pushed_at")]
        public DateTimeOffset PushedAt { get; set; }

        [JsonProperty("git_url")]
        public Uri GitUrl { get; set; }

        [JsonProperty("ssh_url")]
        public Uri SshUrl { get; set; }

        [JsonProperty("clone_url")]
        public Uri CloneUrl { get; set; }

        [JsonProperty("svn_url")]
        public Uri SvnUrl { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("stargazers_count")]
        public long StargazersCount { get; set; }

        [JsonProperty("watchers_count")]
        public long WatchersCount { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        [JsonProperty("has_projects")]
        public bool HasProjects { get; set; }

        [JsonProperty("has_downloads")]
        public bool HasDownloads { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("has_pages")]
        public bool HasPages { get; set; }

        [JsonProperty("forks_count")]
        public long ForksCount { get; set; }

        [JsonProperty("mirror_url")]
        public Uri MirrorUrl { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("open_issues_count")]
        public long OpenIssuesCount { get; set; }

        [JsonProperty("license")]
        public License License { get; set; }

        [JsonProperty("forks")]
        public long Forks { get; set; }

        [JsonProperty("open_issues")]
        public long OpenIssues { get; set; }

        [JsonProperty("watchers")]
        public long Watchers { get; set; }

        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }
    }
}
