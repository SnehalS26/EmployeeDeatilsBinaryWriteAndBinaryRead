using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDeatilsBWandBR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                String path = @"C:\DP4-Laksha";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder already exist");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\Employee.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File already exist");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\Employee.dat";
                FileStream fileStream = new FileStream(path, FileMode.Create , FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                binaryWriter.Write(Convert.ToInt32(textempid.Text));
                binaryWriter.Write(textempname.Text);
                binaryWriter.Write(Convert.ToInt32(textempsalary.Text));
                binaryWriter.Close();
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\Employee.dat";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                textempid.Text = binaryReader.ReadInt32().ToString();
                textempname.Text = binaryReader.ReadString().ToString();
                textempsalary.Text = binaryReader.ReadInt32().ToString();
                binaryReader.Close();
                fileStream.Close();
      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
