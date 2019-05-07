using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindInLogBuildFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFileWithFiles_Click(object sender, EventArgs e)
        {
            OpenFolder open = new OpenFolder();
            open.openFolderWithFile();
        }

        private void buttonOpenFileWithLogFile_Click(object sender, EventArgs e)
        {
            OpenFolder open = new OpenFolder();
            open.openFolderWithLogCompiled();
        }

        private void buttonOpenReport_Click(object sender, EventArgs e)
        {
            WorkExcel workExcel = new WorkExcel();
            workExcel.DisplayInExcelNotFoundFile();
        }
    }
}
