using Steeltoe.Discovery.Client;
using Validator.Services;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Validator.Initializer;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDiscoveryClient();
IConfiguration config = builder.Configuration;
Initializer.init(ref config);

string serviceName = ServiceNameParser.serviceName;

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
app.MapGrpcService<ValidatorService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");



app.Run();
