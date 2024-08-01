using GrpcMessageNode.Initializer;
using GrpcMessageNode.Services;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        builder.Services.AddGrpc();
        
        builder.Services.AddDiscoveryClient(builder.Configuration);

        IConfiguration config = builder.Configuration;
        Initializer.init(ref config);
        string serviceName = ServiceNameParser.serviceName;

        /*builder.Logging.AddOpenTelemetry(options =>
        {
            options
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName))
                .AddConsoleExporter();

        });*/


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

       
        app.MapGrpcService<SendMessageService>();
        

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();

        //Console.WriteLine("Hello"); 
    }
}   

