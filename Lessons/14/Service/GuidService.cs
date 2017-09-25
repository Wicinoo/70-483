using System;

namespace Lessons._14.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GuidService" in both code and config file together.
    public class GuidService : IGuidService
    {
        public string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
