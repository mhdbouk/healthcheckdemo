using System.Net.Http.Json;

namespace Todo.Func;

public class SlackApiClient
{
    private readonly HttpClient _httpClient;
    public SlackApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
    {
        // More info about slack webhook here https://api.slack.com/messaging/webhooks
        await _httpClient.PostAsJsonAsync("/services/T00000000/B00000000/XXXXXXXXXXXXXXXXXXXXXXXX", new
        {
            channel = "#notifications",
            text = message,
        }, cancellationToken);
    }
}
