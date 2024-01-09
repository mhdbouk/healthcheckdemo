using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Func;

var host = new HostBuilder()
           .ConfigureFunctionsWorkerDefaults()
           .ConfigureServices(services =>
           {
               services.AddHttpClient<TodoApiClient>(client =>
               {
                   client.BaseAddress = new Uri("http://localhost:5203");
               });
               
               services.AddHttpClient<SlackApiClient>(client =>
               { 
                   client.BaseAddress = new Uri("https://hooks.slack.com");
               });
           })
           .Build();

host.Run();
