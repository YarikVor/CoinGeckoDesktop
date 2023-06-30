namespace CoinGecko.Api.Dto.Coins;

public class DeveloperData
{
    public int Forks { get; set; }
    public int Stars { get; set; }
    public int Subscribers { get; set; }
    public int TotalIssues { get; set; }
    public int ClosedIssues { get; set; }
    public int PullRequestsMerged { get; set; }
    public int PullRequestContributors { get; set; }
    public CodeAdditionsDeletions4Weeks CodeAdditionsDeletions4Weeks { get; set; }
    public int CommitCount4Weeks { get; set; }
    public object[] Last4WeeksCommitActivitySeries { get; set; }
}