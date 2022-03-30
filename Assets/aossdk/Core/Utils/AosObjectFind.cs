using System.Collections.Generic;
using System.Linq;

namespace AosSdk.Core.Utils
{
    public static class AosObjectFind
    {
        public static AosObjectBase FindAosObjectByGuid(IEnumerable<AosObjectBase> aosObjectBaseList, string guid)
        {
            return aosObjectBaseList.FirstOrDefault(aosObject => aosObject.objectStaticGuid == guid);
        }
    }
}