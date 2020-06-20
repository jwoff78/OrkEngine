using System;
using BEPUutilities.DataStructures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public static class RawListExtensions
    {
        public static ArraySegment<T> GetArraySegment<T>(this RawList<T> rawList)
        {
            return new ArraySegment<T>(rawList.Elements, 0, rawList.Count);
        }
    }
}
