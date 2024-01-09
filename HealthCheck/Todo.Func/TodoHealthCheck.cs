using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Todo.Func;

public class TodoHealthCheck
{
    private readonly ILogger _logger;
    private readonly TodoApiClient _todoApiClient;
    private readonly SlackApiClient _slackApiClient;
    public TodoHealthCheck(ILoggerFactory loggerFactory, TodoApiClient todoApiClient, SlackApiClient slackApiClient)
    {
        _todoApiClient = todoApiClient;
        _slackApiClient = slackApiClient;
        _logger = loggerFactory.CreateLogger<TodoHealthCheck>();
    }

    [Function("TodoHealthCheck")]
    public async Task RunAsync([TimerTrigger("0 * * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        var response = await _todoApiClient.CheckHealthAsync();
        if (response.Status.Equals("Unhealthy", StringComparison.OrdinalIgnoreCase))
        {
            _logger.LogError("Unhealthy!");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Todo.Api is {response.Status}");
            foreach (var item in response.Entries.Where(x => x.Value.Status.Equals("Unhealthy", StringComparison.OrdinalIgnoreCase)))
            {
                sb.AppendLine($"{item.Key} - {item.Value.Status}");
                sb.AppendLine(item.Value.Exception);
                sb.AppendLine();
            }

            await _slackApiClient.SendMessageAsync(sb.ToString());
        }
        else
        {
            _logger.LogInformation("Healthy!");
        }
    }
}










