using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class Links
{
    [JsonPropertyName("homepage")]
    public List<string> Homepage { get; set; } = null!;

    [JsonPropertyName("blockchain_site")]
    public List<string> BlockchainSite { get; set; } = null!;

    [JsonPropertyName("official_forum_url")]
    public List<string> OfficialForumUrl { get; set; } = null!;

    [JsonPropertyName("chat_url")]
    public List<string> ChatUrl { get; set; } = null!;

    [JsonPropertyName("announcement_url")]
    public List<string> AnnouncementUrl { get; set; } = null!;

    [JsonPropertyName("twitter_screen_name")]
    public string TwitterScreenName { get; set; } = null!;

    [JsonPropertyName("facebook_username")]
    public string FacebookUsername { get; set; } = null!;

    [JsonPropertyName("bitcointalk_thread_identifier")]
    public int? BitcointalkThreadIdentifier { get; set; } = null!;

    [JsonPropertyName("telegram_channel_identifier")]
    public string TelegramChannelIdentifier { get; set; } = null!;

    [JsonPropertyName("subreddit_url")]
    public string SubredditUrl { get; set; } = null!;

    [JsonPropertyName("repos_url")]
    public ReposUrl ReposUrl { get; set; } = null!;
}