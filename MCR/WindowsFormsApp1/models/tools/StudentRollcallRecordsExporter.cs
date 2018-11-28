using MCR.models.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace MCR.tools
{
    /// <summary>
    /// A Rollcall record exporter util.
    /// </summary>
    public class StudentSignRecordExporter
    {
        public static void toTxt(StudentRollcallRecord record, string filePath)
        {
            if (!filePath.EndsWith(".txt"))
                filePath = filePath + ".txt";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("標題 : " + record.title);
            stringBuilder.AppendLine("日期 : " + record.datetime);
            stringBuilder.AppendLine("課程名稱 : " + record.session.name);
            stringBuilder.AppendLine("課程代號 : " + record.session.subjectNumber);
            stringBuilder.AppendLine(" 姓名 " + " " + " 出席狀況 ");
            for (int i = 0; i < record.rollcallStudents.Count; i++)
                stringBuilder.AppendLine(record.rollcallStudents[i].name + "  " + 
                    record.rollcallStudents[i].stateToString());
            File.WriteAllText(filePath , stringBuilder.ToString());
        }

        public static void toExcel(StudentRollcallRecord record, string filePath)
        {
            string[] sessionHeader = { " 標題", "日期", "課程名稱", "課程代碼" };
            string[] signStatesHeader = { "姓名", "出席狀況" };

            //order should be: Application -> Workbook -> Worksheet -> Range -> Cell
            Application application = new Application();
            application.Visible = false;
            application.UserControl = false;
            
            Workbook workbook = application.Workbooks.Add(Missing.Value);
            Worksheet worksheet = (Worksheet)workbook.ActiveSheet;

            worksheet.Cells[2, 1] = record.title;
            worksheet.Cells[2, 2] = record.datetime.ToShortDateString();
            worksheet.Cells[2, 3] = record.session.name;
            worksheet.Cells[2, 4] = record.session.subjectNumber;

            worksheet.get_Range("A1", "D1").Value2 = sessionHeader;
            worksheet.get_Range("A1", "D1").EntireColumn.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            worksheet.get_Range("A4", "B4").Value2 = signStatesHeader;
            worksheet.get_Range("A4", "B4").EntireColumn.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            for (int i = 0; i < record.rollcallStudents.Count ; i++)
            {
                //starts from row 5
                worksheet.Cells[i + 5, 1] = record.rollcallStudents[i].name;
                var state = record.rollcallStudents[i].state;
                worksheet.Cells[i + 5, 2] = record.rollcallStudents[i].stateToString();
            }

            int rowCount = 4 + record.rollcallStudents.Count;
            worksheet.get_Range("A1", "A" + rowCount).EntireColumn.AutoFit();
            worksheet.get_Range("B1", "B" + rowCount).EntireColumn.AutoFit();



            workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            workbook.Close();
            application.Quit();
        }

        public static void toGoogleSpreadSheet(StudentRollcallRecord record)
        {

        }
        
    }
}
