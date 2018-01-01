using System;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Lessons._14
{
    public class TaskC
    {
        public static void Run()
        {
            using (WebServiceHost host = new WebServiceHost(typeof (GuidService), new Uri("http://localhost:8000/")))
            {
                host.AddServiceEndpoint(typeof(IGuidService), new WebHttpBinding(), "");
                host.Open();
                Console.WriteLine("Service is running");
                Console.WriteLine("Press enter to quit...");
                Console.ReadLine();
            } 
        }
    }

    [ServiceContract]
    public interface IGuidService
    {
        [OperationContract]
        [WebGet]
        string GetNewGuid();
    }
    public class GuidService : IGuidService
    {
        public string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
