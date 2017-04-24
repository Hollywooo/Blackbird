using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;


namespace StockCompiler
{
    class ExcelImport
    {
        public static DataTable excelImportDEPRECATED()
        {
            //Deprecated method; uses hard-coded filename and extension.  Replaced by 

            string stringExcelPath = Filepath.GetFolderPath();
            string stringConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0 XML;data source=" + stringExcelPath + "\\GOOG.xlsx";
            MessageBox.Show(stringConnection);
            DataTable dataGOOG = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(stringConnection))
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dtSheet.Rows.Count != 1)
                    MessageBox.Show("Too Many Rows");
                else
                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString();
                        if (!sheetName.EndsWith("$"))
                            continue;
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(dataGOOG);
                    }
                cmd = null;
                conn.Close();
            }

            //return the datatable for use elsewhere
            return dataGOOG;
        }

        public static DataTable ExcelImportToDataTable()
        {
            //Construct connection string using source specifications and full path including filename from Filepath.GetFullPath()
            string stringConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0 XML;data source=" + StockCompiler.Filepath.GetFullPath();

            //Confirm connection string
            MessageBox.Show(stringConnection);

            //Initialize receiving datatable
            DataTable importedTable = new DataTable();

            //OLE connection to Excel table
            using (OleDbConnection conn = new OleDbConnection(stringConnection))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dtSheet.Rows.Count != 1)
                    MessageBox.Show("Too Many Rows");
                else
                    //Populate the datatable
                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString();
                        if (!sheetName.EndsWith("$"))
                            continue;
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(importedTable);
                    }
                cmd = null;
                conn.Close();
            }

            //return the datatable for use elsewhere
            return importedTable;
        }
    }
}
