using GrpcMessageNode.Initializer;
using GrpcMessageNode.Services;
using Microsoft.AspNetCore.Server.Kestrel.Https;
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
            

        builder.Services.AddGrpc();
        
        builder.Services.AddDiscoveryClient();

        IConfiguration config = builder.Configuration;
        Initializer.init(ref config);
        string serviceName = ServiceNameParser.serviceName;

        //;https://localhost:9091
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

       // app.UseHttpsRedirection();
        app.UseRouting();
        app.UseHttpsRedirection();
        
        app.MapGrpcService<SendMessageService>();
        

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();

        //Console.WriteLine("Hello"); 
    }
}   

