using System.Text.Json;

namespace Todo.Func;

public class TodoApiClient
{
    private readonly HttpClient _httpClient;
    public TodoApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HealthReport> CheckHealthAsync()
    {
        var response = await _httpClient.GetAsync("_health");
        
        
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true,
        };

        var contentStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<HealthReport>(contentStream, jsonOptions) 
               ?? throw new JsonException("Deserialization failed");
    }
}

public class HealthReport
{
    public required string Status { get; set; }
    public required string TotalDuration { get; set; }
    public Dictionary<string, Entry> Entries { get; set; } = [];
}

public class Entry
{
    public IReadOnlyDictionary<string, object> Data { get; set; } = null!;
    public string? Description { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Exception { get; set; }
    public required string Status { get; set; }
    public IEnumerable<string>? Tags { get; set; }
}




