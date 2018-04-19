using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PostgreSQL_APP
{
    public interface IController
    {
        void WriteToFile(string sheetName, DataTable tableName, string fileName);
    }
}
