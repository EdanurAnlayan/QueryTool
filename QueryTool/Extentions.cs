using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryTool
{
    class Extentions
    {
        public static string GetDirection()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        public static string GetFileDirection(string fileName)
        {
            return Path.Combine(GetDirection(), fileName);
        }
    }
}
