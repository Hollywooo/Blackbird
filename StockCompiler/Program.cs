using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StockCompiler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Run the excel import

            DataTable testDT = new DataTable();
            testDT = StockCompiler.ExcelImport.ExcelImportToDataTable();
            Console.WriteLine("testDT imported");

            //Check the import

            DataRow[] currentRows = testDT.Select();
            if (currentRows.Length < 1)
                Console.WriteLine("No Current Rows Found");
            else
            {
                foreach (DataColumn column in testDT.Columns)
                {
                    Console.Write(column.ColumnName + "\t");
                }
                foreach (DataRow row in currentRows)
                {
                    Console.WriteLine();
                    for (int x = 0; x < testDT.Columns.Count; x++)
                    {
                        Console.Write(row[x].ToString() + "\t");
                    }
                }
            }

            //Hold the console for inspection
            Console.ReadKey();
        }
    }
}
