using Lessons._14.Service;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lessons._14
{
    public static class TaskC
    {
        public static void Run()
        {
            RunSelfHostService();
        }

        private static void OpenDefaultBrowser(string address)
        {
            System.Diagnostics.Process.Start(address);
        }

        private static void RunSelfHostService()
        {
            try
            {
                Uri httpBaseAddress = new Uri("http://localhost:4321/GuidService");

                using (ServiceHost serviceHost = new ServiceHost(typeof(GuidService), httpBaseAddress))
                {
                    //Metadata Exchange
                    ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                    serviceBehavior.HttpGetEnabled = true;
                    serviceHost.Description.Behaviors.Add(serviceBehavior);

                    serviceHost.Open();
                    Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
                    
                    OpenDefaultBrowser(httpBaseAddress.ToString());
                    Console.ReadKey();

                    serviceHost.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("There is an issue with StudentService" + ex.Message);
            }
        }
    }
}
