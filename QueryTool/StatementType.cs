using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryTool
{
    public enum StatementType
    {
        select = 0,
        insert=1,
        update=2,
        delete=3,
        batch=4,
        SELECT=5,
        INSERT=6,
        UPDATE=7,
        DELETE=8,
        BATCH=9
    }
}
