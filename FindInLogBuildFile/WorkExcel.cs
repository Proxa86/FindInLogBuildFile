using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace FindInLogBuildFile
{
    class WorkExcel
    {
        static List<ClassFile> FileNotFound { get; set; }
        public WorkExcel() { }
        public WorkExcel(List<ClassFile> classFiles)
        {
            FileNotFound = classFiles;
        }
        ////Главное
        //private Excel.Application excelapp;
        ////private Excel.Window excelWindow;

        //// книги
        //private Excel.Workbooks excelappworkbooks;
        //// одна книга
        //private Excel.Workbook excelappworkbook;

        //// страницы
        //private Excel.Sheets excelsheets;
        //private Excel.Worksheet excelworksheet;

        //// ячейки
        //private Excel.Range excelcells;

        //public void createExcelFile()
        //{
        //    // Создаем эксель файл
        //    excelapp = new Excel.Application();
        //    // Указать сколько будет листов
        //    excelapp.SheetsInNewWorkbook = 3;
        //    // Добавляем в книгу
        //    excelapp.Workbooks.Add(Type.Missing);
        //    //======= remark
        //    // чтобы добавить вторую книгу 
        //    // excelapp.SheetsInNewWorkbook = 6;
        //    // excelapp.Workbooks.Add(Type.Missing);
        //    //======== end_remark
        //    // Получаем набор ссылок на объекты Workbook (книги)
        //    excelappworkbooks = excelapp.Workbooks;
        //    // Получаем ссылку на книгу 1 - нумерация от 1
        //    excelappworkbook = excelappworkbooks[1];
        //    // Задаем формат
        //    excelapp.DefaultSaveFormat = Excel.XlFileFormat.xlAddIn8;
        //    //========== remark
        //    // чтобы сохранить в формате html
        //    // excelapp.DefaultSaveFormat=Excel.XlFileFormat.xlHtml;
        //    //========== end_remark
        //    // Создаем файл
        //    excelappworkbook.SaveAs(@"D:\tmp_markers.xls",
        //        Excel.XlFileFormat.xlExcel12,
        //        Type.Missing,
        //        Type.Missing,
        //        Type.Missing,
        //        Type.Missing,
        //        Excel.XlSaveAsAccessMode.xlShared,
        //        Type.Missing,
        //        Type.Missing,
        //        Type.Missing,
        //        Type.Missing,
        //        Type.Missing);
        //    // Открываем созданный файл
        //    excelappworkbook = excelapp.Workbooks.Open(@"D:\tmp_markers.xls",
        //        Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    // Получаем набор ссылок на страницы в данной книге
        //    excelsheets = excelappworkbook.Worksheets;
        //    // Выбираем страницу 1 - нумерация  с 1
        //    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
        //    //// Выделяем выбранные ячейки
        //    //excelcells = excelworksheet.get_Range("A1", "D15");
        //    //// Записываем значение
        //    //excelcells.Value2 = 10.2;

        //    excelcells = excelworksheet.get_Range("A2", "A2");
        //    excelcells.Value2 = "Number tmp marker";

        //    excelcells = excelworksheet.get_Range("B2", "B2");
        //    excelcells.Value2 = "Path src";




        //    // Сохраняем
        //    excelappworkbook.Save();
        //    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!OK");

        //}


        public void DisplayInExcelNotFoundFile()
        {
            try
            {
                var excelApp = new Excel.Application();

                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
                worksheet.Cells[1, "A"] = "Name File";
                worksheet.Cells[1, "B"] = "Path";

                int i = 0;
                foreach (var file in FileNotFound)
                {
                    worksheet.Cells[i + 2, "A"] = file.NameFile;
                    worksheet.Cells[i + 2, "B"] = file.PathFile;
                    ++i;
                }

                worksheet.Columns[1].AutoFit();
                worksheet.Columns[2].AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Markers in bin not found!");
            }



        }

        //public void DisplayInExcelFoundInBinMarker(List<ResultMarkersInBin> lResultMarkerInBin)
        //{
        //    try
        //    {
        //        var excelApp = new Excel.Application();

        //        excelApp.Visible = true;
        //        excelApp.Workbooks.Add();
        //        Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
        //        //worksheet.Cells[1, "A"] = "Number marker";
        //        //worksheet.Cells[1, "B"] = "Path";

        //        int i = 1;
        //        int j = 0;
        //        foreach (var bin in lResultMarkerInBin)
        //        {
        //            worksheet.Cells[i, "A"] = bin.Path;

        //            foreach (var marker in bin.LMarkerInBin)
        //            {
        //                worksheet.Cells[i + 1, "B"] = marker.Number;
        //                worksheet.Cells[i + 1, "C"] = marker.Path;
        //                ++i;
        //            }
        //            ++i;
        //        }

        //        worksheet.Columns[2].AutoFit();
        //        worksheet.Columns[3].AutoFit();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Markers in bin not found!");
        //    }


        //}

        //public void DisplayInExcelNotFoundMarker(List<MarkerSrc> lMarkerSrcNotFoundInBin)
        //{
        //    try
        //    {
        //        var excelApp = new Excel.Application();

        //        excelApp.Visible = true;
        //        excelApp.Workbooks.Add();
        //        Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
        //        worksheet.Cells[1, "A"] = "Number marker";
        //        worksheet.Cells[1, "B"] = "Path";

        //        int i = 0;
        //        foreach (var marker in lMarkerSrcNotFoundInBin)
        //        {
        //            worksheet.Cells[i + 2, "A"] = marker.Number;
        //            worksheet.Cells[i + 2, "B"] = marker.Path;
        //            ++i;
        //        }

        //        worksheet.Columns[1].AutoFit();
        //        worksheet.Columns[2].AutoFit();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Markers not found in bin!");
        //    }



        //}









    }
}
