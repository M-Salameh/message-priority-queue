using Microsoft.Extensions.Options;

namespace GrpcMessageNode.Initializer
{
	public class ServiceNameParser
	{
		public static string serviceName = "";
		public static void setServiceName(ref IConfiguration config)
        {
			string? name = config.GetSection("OpenTelemetry").GetSection("ServiceName").Value;
			if (name == null)
            {
				throw new ArgumentException("Service Name Not Defined in appsettings.json");
            }
			serviceName = name;
        }
    }
}
