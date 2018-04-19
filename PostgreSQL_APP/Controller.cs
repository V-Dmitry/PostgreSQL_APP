using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace PostgreSQL_APP
{
    class Controller: IController
    {
        Excel ex = null;
        public Controller()
        {
            ex = new PostgreSQL_APP.Excel();
        }
        public void WriteToFile(string sheetName, DataTable tableName, string fileName)
        {
            ex.CreateSheet(sheetName, tableName);
            ex.CreateCells(sheetName);
            ex.WriteToFile(fileName);
        }
    }
}
