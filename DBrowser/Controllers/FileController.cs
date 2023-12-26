using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser.Controllers
{
    internal class FileController
    {
        public void WriteInFile(string filePath, string content)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.Write(content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving SQL file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ReadFromFile(string filePath)
        {
            string contnent = File.ReadAllText(filePath);
            return contnent;
        }
    }
    
}
