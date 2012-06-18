using System;
using System.ServiceModel;

namespace PricingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(PricingService)))
            {
                host.Open();
                Console.WriteLine("Fx Rate Pricing Service is running...");
                Console.WriteLine("Service address: " + host.BaseAddresses[0]);
                Console.Read();
            }
        }
    }
}
