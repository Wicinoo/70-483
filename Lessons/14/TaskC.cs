using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lessons._14
{
	[ServiceContract]
	public interface IService
	{
		[OperationContract]
		[WebGet(UriTemplate = "GetNewGuid")]
		string GetNewGuid();
	}


	public class Service : IService
	{
		public string GetNewGuid()
		{
			return new Guid().ToString();
		}
	}


	public static class TaskC
	{
		public static void Run()
		{
			//this will probably work but I really dont have the time to deal with windows blocking this
			WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/"));

			ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
				
			host.Open();

			Console.ReadKey();
		}
		
	}
}
