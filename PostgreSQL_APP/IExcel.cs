using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PostgreSQL_APP
{
    public interface IExcel
    {
        void CreateSheet(string sheetName, DataTable dataSource);
        void CreateCells(string sheetName);
        void WriteToFile(string fileName);
    }
}
