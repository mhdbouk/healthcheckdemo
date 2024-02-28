# Health Check Demo

This is the source code for the YouTube video "The Best Way To Check Health In .NET". It demonstrates how to implement health checks in .NET 8 for a web API and an Azure Function for monitoring. It also demonstrates how to use the [HealthChecks NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks) to implement health checks for SQL Server and Redis. Finally, it demonstrates how to use the [HealthChecks.UI NuGet package](https://www.nuget.org/packages/AspNetCore.HealthChecks.UI) to display the health checks in a web UI.

### Check the YouTube video here

[![The Best Way To Check Health In .NET](https://i3.ytimg.com/vi/EIxZ9SzO_OY/mqdefault.jpg)](https://www.youtube.com/watch?v=EIxZ9SzO_OY)

[The Best Way To Check Health In .NET](https://www.youtube.com/watch?v=EIxZ9SzO_OY)

## Project Structure

The project is divided into two main parts:

1. `Todo.Api`: This is the main API for the project. It includes health checks for Redis and SQL Server, implemented in [`RedisHealthCheck.cs`](HealthCheck/Todo.Api/Health/RedisHealthCheck.cs) and [`SqlServerHealthCheck.cs`](HealthCheck/Todo.Api/Health/SqlServerHealthCheck.cs) respectively.

2. `Todo.Func`: This part of the project contains Azure Functions and includes a health check implemented in [`TodoHealthCheck.cs`](HealthCheck/Todo.Func/TodoHealthCheck.cs). It also contains a Slack API client implemented in [`SlackApiClient.cs`](HealthCheck/Todo.Func/SlackApiClient.cs) and a Todo API client implemented in [`TodoApiClient.cs`](HealthCheck/Todo.Func/TodoApiClient.cs).

## How to Run

To run the project, open the `HealthCheck.sln` file in Visual Studio or Rider and run both the `Todo.Api` and `Todo.Func` projects. Make sure to create a Slack Webhook before using the function for monitoring https://api.slack.com/messaging/webhooks

## License

This project is licensed under the terms of the license provided in the [LICENSE](LICENSE) file.
