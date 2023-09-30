using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial2.DB.Connection
{
    internal interface IDBAccess
    {
        object SelectAll();
        object Select(object dto);
        object Insert(object dto);
        object Update(object dto);
        object Delete(object dto);
    }
}
