using System.Threading.Tasks;

namespace Lessons._02
{
    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }
}