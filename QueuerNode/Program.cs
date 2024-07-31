using Scheduler.MongoMessages;
using SchedulerNode.RedisQueuer;
using SchedulerNode.Services;
using Steeltoe.Discovery.Client;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDiscoveryClient();

MessageQueues.init();

MongoMessagesShceduler.init();

const string serviceName = "Scheduler-1";

builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddConsoleExporter();

});


builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddGrpcClientInstrumentation()
          .AddJaegerExporter())

      .WithMetrics(metrics => metrics
      .AddAspNetCoreInstrumentation()
      );


var app = builder.Build();



// Configure the HTTP request pipeline.
app.MapGrpcService<QueueMessageService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
