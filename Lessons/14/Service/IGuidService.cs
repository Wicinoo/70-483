using System.ServiceModel;

namespace Lessons._14.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGuidService" in both code and config file together.
    [ServiceContract(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/")]
    public interface IGuidService
    {
        [OperationContract]
        string GetNewGuid();
    }
}
