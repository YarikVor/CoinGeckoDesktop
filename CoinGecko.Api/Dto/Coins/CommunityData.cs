using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class CommunityData
{
    [JsonPropertyName("facebook_likes")]
    public float? FacebookLikes { get; set; }

    [JsonPropertyName("twitter_followers")]
    public float? TwitterFollowers { get; set; }

    [JsonPropertyName("reddit_average_posts_48h")]
    public float? RedditAveragePosts48H { get; set; }

    [JsonPropertyName("reddit_average_comments_48h")]
    public float? RedditAverageComments48H { get; set; }

    [JsonPropertyName("reddit_subscribers")]
    public float? RedditSubscribers { get; set; }

    [JsonPropertyName("reddit_accounts_active_48h")]
    public float? RedditAccountsActive48H { get; set; }

    [JsonPropertyName("telegram_channel_user_count")]
    public float? TelegramChannelUserCount { get; set; }
}