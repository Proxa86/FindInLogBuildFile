using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindInLogBuildFile
{
    class OpenFolder
    {

        public void openFolderWithFile()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"E:\share\83t415(A190)\buildtools_tarc\";
            fbd.ShowNewFolderButton = false;

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //FindTmpMarker findTmpMarker = new FindTmpMarker(fbd);
                    //findTmpMarker.findTmpMarkerWithSrc();
                    FindFileInFolder findFileInFolder = new FindFileInFolder(fbd);
                    findFileInFolder.searchFiles();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error: can't open folder.\nOriginal error: "+ e.Message);
                }
            }
        }

        public void openFolderWithLogCompiled()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"E:\share\83t415(A190)\LogBuild\";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FindFileInLogFile findFileInLogFile = new FindFileInLogFile(fbd);
                    findFileInLogFile.parsingLogFile();
                    //FindTmpMarker findTmpMarker = new FindTmpMarker(fbd);
                    //findTmpMarker.findTmpMarkerWithBin();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: can't open folder.\nOriginal error: " + e.Message);
                }
            }
        }

        //public void openFolderWithSrcForInsertMarker()
        //{
        //    FolderBrowserDialog fbd = new FolderBrowserDialog();
        //    fbd.SelectedPath = @"C:\";
        //    fbd.ShowNewFolderButton = false;

        //    if (fbd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            InsertMarker insertMarker = new InsertMarker(fbd);
        //            insertMarker.insertMarker();
                    
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show("Error: can't open folder.\nOriginal error: " + e.Message);
        //        }
        //    }
        //}
    }
}
