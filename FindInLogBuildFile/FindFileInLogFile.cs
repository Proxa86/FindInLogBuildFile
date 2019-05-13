using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindInLogBuildFile
{
    class FindFileInLogFile
    {
        FolderBrowserDialog fbd;
        List<string> lLogFile { get; set; }

        public FindFileInLogFile(FolderBrowserDialog fbd)
        {
            this.fbd = fbd;
        }

        public void parsingLogFile()
        {
            lLogFile = new List<string>();
            List<string[]> lParentFilters = new List<string[]>();

            lParentFilters.Add(Directory.GetFiles(fbd.SelectedPath, "*.txt", SearchOption.AllDirectories));
            List<FileFind> lFileFind = new List<FileFind>();

            List<ClassFile> lFilesC = FindFileInFolder.lFilesC;
            //List<ClassFile> lFilesH = FindFileInFolder.lFilesH;

            List<ClassFile> lFileNotFind = new List<ClassFile>();
            lFileNotFind.AddRange(lFilesC);
            //lFileNotFind.AddRange(lFilesH);

            try
            {
                foreach (var filter in lParentFilters)
                {
                    ClassFile file = new ClassFile();
                    foreach (var path in filter)
                    {
                        //string[] allLinesInFile = File.ReadAllLines(path);
                        using (var f = File.OpenText(path))
                        {
                            int k = 0;
                            int i = 0;
                            int j = 1;
                            
                            while (!f.EndOfStream)
                            {
                                string line = f.ReadLine();
                                Console.WriteLine(++k);
                                //++k;
                                //int index = -1;
                                string paternPlus = "\\+";
                                string nameFile = "";
                                int d = 0;
                                foreach (var ffile in lFilesC)
                                {
                                    //++index;
                                    nameFile = ffile.NameFile;
                                    FileFind fileFind = new FileFind();
                                    Console.WriteLine(d++ + " " + nameFile);
                                    Regex regex = new Regex(paternPlus);
                                    Match match = regex.Match(nameFile);
                                    if (match.Success)
                                    {
                                        //char[] arr2 = ffile.NameFile.ToCharArray();
                                        //string [] arr = ffile.NameFile.Split(new char [] { '+' });
                                        nameFile = ffile.NameFile.Replace("+", "\\+");
                                        string compileFile1 = nameFile + ".o";
                                        string compileFile2 = Path.GetFileNameWithoutExtension(ffile.PathFile) + ".o";
                                        string compileFile3 = Path.GetFileNameWithoutExtension(ffile.PathFile) + ".lo";
                                        compileFile2 = compileFile2.Replace("+", "\\+");
                                        compileFile3 = compileFile3.Replace("+", "\\+");
                                        string str = @"(/" + compileFile1 + @"\s{0,})|(/" + compileFile2 + @"\s{0,})|(/" + compileFile3 + @"\s{0,})|(/" + ffile.NameFile + "\\s{0,})|([\\t\\s]" + compileFile1 + "\\s{0,})|([\\s\\t]" + compileFile2 + "\\s{0,})|([\\s\\t]" + compileFile3 + "\\s{0,})|([\\t\\s]" + ffile.NameFile + "\\s{0,})";
                                        regex = new Regex(str);
                                        match = regex.Match(line);
                                        if (match.Success)
                                        {
                                            fileFind.NameFile = ffile.NameFile;
                                            fileFind.NumberFile = ++i;
                                            fileFind.PathFile = ffile.PathFile;
                                            fileFind.NumberStringLogFile = j;
                                            fileFind.StringLogFile = line;

                                            lFileFind.Add(fileFind);
                                            var df = lFileNotFind.FirstOrDefault(x => x.NameFile.Equals(ffile.NameFile));
                                            if (df != null)
                                                lFileNotFind.Remove(df);
                                        }
                                    }
                                    else
                                    {
                                        string compileFile1 = ffile.NameFile + ".o";
                                        string compileFile2 = Path.GetFileNameWithoutExtension(ffile.PathFile) + ".o";
                                        string compileFile3 = Path.GetFileNameWithoutExtension(ffile.PathFile) + ".lo";
                                        string str = @"(/" + compileFile1 + @"\s{0,})|(/" + compileFile2 + @"\s{0,})|(/" + compileFile3 + @"\s{0,})|(/" + ffile.NameFile + "\\s{0,})|([\\t\\s]" + compileFile1 + "\\s{0,})|([\\s\\t]" + compileFile2 + "\\s{0,})|([\\s\\t]" + compileFile3 + "\\s{0,})|([\\t\\s]" + ffile.NameFile + "\\s{0,})";
                                        regex = new Regex(str);
                                        match = regex.Match(line);
                                        if (match.Success)
                                        {
                                            fileFind.NameFile = ffile.NameFile;
                                            fileFind.NumberFile = ++i;
                                            fileFind.PathFile = ffile.PathFile;
                                            fileFind.NumberStringLogFile = j;
                                            fileFind.StringLogFile = line;

                                            lFileFind.Add(fileFind);
                                            var df = lFileNotFind.FirstOrDefault(x => x.NameFile.Equals(ffile.NameFile));
                                            if (df != null)
                                                lFileNotFind.Remove(df);
                                        }
                                    }
                                    
                                }

                                //foreach (var ffile in lFilesH)
                                //{
                                //    //++index;
                                //    FileFind fileFind = new FileFind();
                                //    nameFile = ffile.NameFile;
                                //    Console.WriteLine(d++ + " " + nameFile);
                                //    Regex regex = new Regex(paternPlus);
                                //    Match match = regex.Match(nameFile);
                                //    if (match.Success)
                                //    {
                                //        nameFile = ffile.NameFile.Replace("+", "\\+");
                                //        string str = @"(/" + nameFile + @")|(/" + nameFile + ")|(\\s" + nameFile + "\\s)|(\\s" + nameFile + "\\s)";
                                //        regex = new Regex(str);
                                //        match = regex.Match(line);
                                //        if (match.Success)
                                //        {
                                //            fileFind.NameFile = ffile.NameFile;
                                //            fileFind.NumberFile = ++i;
                                //            fileFind.PathFile = ffile.PathFile;
                                //            fileFind.NumberStringLogFile = j;
                                //            fileFind.StringLogFile = line;

                                //            lFileFind.Add(fileFind);
                                //            var df = lFileNotFind.FirstOrDefault(x => x.NameFile.Equals(ffile.NameFile));
                                //            if (df != null)
                                //                lFileNotFind.Remove(df);
                                //        }
                                //    }
                                //    else
                                //    {
                                //        string str = @"(/" + ffile.NameFile + @")|(/" + ffile.NameFile + ")|(\\s" + ffile.NameFile + "\\s)|(\\s" + ffile.NameFile + "\\s)";
                                //        regex = new Regex(str);
                                //        match = regex.Match(line);
                                //        if (match.Success)
                                //        {
                                //            fileFind.NameFile = ffile.NameFile;
                                //            fileFind.NumberFile = ++i;
                                //            fileFind.PathFile = ffile.PathFile;
                                //            fileFind.NumberStringLogFile = j;
                                //            fileFind.StringLogFile = line;

                                //            lFileFind.Add(fileFind);
                                //            var df = lFileNotFind.FirstOrDefault(x => x.NameFile.Equals(ffile.NameFile));
                                //            if (df != null)
                                //                lFileNotFind.Remove(df);
                                //        }
                                //    }

                                    
                                //}
                                ++j;
                            }
                            //Console.WriteLine("Found: " +lFileFind.Count);
                            //Console.WriteLine("Not found: " + lFileNotFind.Count);
                            MessageBox.Show("Analise end.");
                            
                        }
                        WorkExcel workExcel = new WorkExcel(lFileNotFind);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
