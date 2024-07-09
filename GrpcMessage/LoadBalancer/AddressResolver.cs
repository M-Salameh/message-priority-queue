using GrpcMessageNode.Services;
using Steeltoe.Discovery;

namespace GrpcMessageNode.LoadBalancer
{
    public class AddressResolver
    {
        private static Random random = new Random();    

        private static int offset = random.Next(200000,int.MaxValue);
        public static string getAddressOfInstance(string instanceName , ref IDiscoveryClient discoveryClient)
        {
            string address = "";
            try
            {
                // instanceName = "Validator" or "QueuerNode" ... etc
                var y = discoveryClient.GetInstances(instanceName); /// write names to config file

                int element = offset % y.Count;

                address = y[element].Uri.ToString();

                offset = 1 + (offset % y.Count);

                return address;
            }
            catch (Exception ex)
            {
                return SendMessageService.ErrorConnection;
            }
        }
    }
}
