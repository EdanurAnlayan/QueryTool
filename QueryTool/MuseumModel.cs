using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryTool
{
    public class MuseumModel
    {
        public string DistId { get; set; }
        public string DistName { get; set; }
        public string DistCon1 { get; set; }
        public string  DistCon2 { get; set; }
        public bool Run { get; set; }
        public int AffectedRowCount { get; set; }
    }
}
