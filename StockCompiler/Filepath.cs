using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCompiler
{
    public class Filepath
    {
                
        public static string GetFolderPath() //Use GetFolderPath for the folder location of a file
        {
            string stringPath;
            FolderBrowserDialog pathFBD = new FolderBrowserDialog();
            DialogResult resultFBD = pathFBD.ShowDialog();
            if (resultFBD == DialogResult.OK)
            {
                stringPath = pathFBD.SelectedPath;
            }
            else
            {
                stringPath = null;
            }
            return stringPath;
        }

        public static string GetFullPath()  //Use GetFullPath for the full location of a file, including filename and extension
        {
            string fullFilePath;
            OpenFileDialog getFullFilePath = new OpenFileDialog();
            DialogResult resultOFD = getFullFilePath.ShowDialog();
            if (resultOFD == DialogResult.OK)
            {
                fullFilePath = getFullFilePath.FileName;
            }
            else
            {
                fullFilePath = null;
            }
            MessageBox.Show(fullFilePath);

            return fullFilePath;
        }
    }

}
