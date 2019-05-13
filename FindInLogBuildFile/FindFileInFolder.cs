using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindInLogBuildFile
{
    class FindFileInFolder
    {
        FolderBrowserDialog fbd;
        static public List<ClassFile> lFilesC { get; set; }
        //static public List<ClassFile> lFilesH { get; set; }

        public FindFileInFolder(FolderBrowserDialog fbd)
        {
            this.fbd = fbd;
        }

        public void searchFiles()
        {
            lFilesC = new List<ClassFile>();
            //lFilesH = new List<ClassFile>();

            List<string[]> lParentFiltersC = new List<string[]>();

            lParentFiltersC.Add(Directory.GetFiles(fbd.SelectedPath, "*.cpp", SearchOption.AllDirectories));
            lParentFiltersC.Add(Directory.GetFiles(fbd.SelectedPath, "*.cc", SearchOption.AllDirectories));
            lParentFiltersC.Add(Directory.GetFiles(fbd.SelectedPath, "*.c", SearchOption.AllDirectories));

            //List<string[]> lParentFiltersH = new List<string[]>();

            //lParentFiltersH.Add(Directory.GetFiles(fbd.SelectedPath, "*.hpp", SearchOption.AllDirectories));
            //lParentFiltersH.Add(Directory.GetFiles(fbd.SelectedPath, "*.hh", SearchOption.AllDirectories));
            //lParentFiltersH.Add(Directory.GetFiles(fbd.SelectedPath, "*.h", SearchOption.AllDirectories));

            try
            {
                foreach (var filter in lParentFiltersC)
                {
                    
                    foreach (var path in filter)
                    {
                        ClassFile file = new ClassFile();
                        file.PathFile = path;
                        file.NameFile = Path.GetFileName(path);
                        Console.WriteLine(file.NameFile);
                        lFilesC.Add(file);
                    }    
                }

                //foreach (var filter in lParentFiltersH)
                //{

                //    foreach (var path in filter)
                //    {
                //        ClassFile file = new ClassFile();
                //        file.PathFile = path;
                //        file.NameFile = Path.GetFileName(path);
                //        Console.WriteLine(file.NameFile);
                //        lFilesH.Add(file);
                //    }
                //}

                MessageBox.Show("End!\nc: " + lFilesC.Count);
                //MessageBox.Show("End!\nc: "+lFilesC.Count + "\nh: "+ lFilesH.Count);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
