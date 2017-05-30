using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._02
{
    public class SiteReader : ISiteReader
    {
        public async Task<string> ReadAsync(string requestUrl)
        {
            using (var wc = new WebClient())
            {
                return await wc.DownloadStringTaskAsync(new Uri(requestUrl));
            }
        }
    }
}
