using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Util
    {
        public static string[] RemoveEmptyStrings(string[] data)
        {
            return data.Where(x => !string.IsNullOrEmpty(x)).ToArray();
		}
    }
}
