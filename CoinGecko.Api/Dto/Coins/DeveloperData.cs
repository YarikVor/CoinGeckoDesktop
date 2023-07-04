using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class DeveloperData
{
    [JsonPropertyName("forks")]
    public int Forks { get; set; }

    [JsonPropertyName("stars")]
    public int Stars { get; set; }

    [JsonPropertyName("subscribers")]
    public int Subscribers { get; set; }

    [JsonPropertyName("total_issues")]
    public int TotalIssues { get; set; }

    [JsonPropertyName("closed_issues")]
    public int ClosedIssues { get; set; }

    [JsonPropertyName("pull_requests_merged")]
    public int PullRequestsMerged { get; set; }

    [JsonPropertyName("pull_request_contributors")]
    public int PullRequestContributors { get; set; }

    [JsonPropertyName("code_additions_deletions_4_weeks")]
    public CodeAdditionsDeletions4Weeks CodeAdditionsDeletions4Weeks { get; set; } = null!;

    [JsonPropertyName("commit_count_4_weeks")]
    public int CommitCount4Weeks { get; set; }

    [JsonPropertyName("last_4_weeks_commit_activity_series")]
    public List<int> Last4WeeksCommitActivitySeries { get; set; } = null!;
}