using MCR.models.viewmodels;
using MCR.tools;
using MCR.utils;
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

namespace MCR.views
{
    public partial class ExportingSignRecordDialog : Form
    {
        private StudentRollcallRecord record;
        private ExportingSignRecordDialog()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public ExportingSignRecordDialog(StudentRollcallRecord record) : this()
        {
            this.record = record;
        }

        private void chooseFileNameBtn_Click(object sender, EventArgs e)
        {
            createAndShowSaveFileDialogForExportingFileName();
        }

        private void createAndShowSaveFileDialogForExportingFileName()
        {
            var outputPath = FileUtils.createDirectoryIfNotExists("output");
            var fileName = record.session.name;
            var chosenPath = DialogUtils.createAndShowDialogForChoosingFilePath(outputPath, fileName);
            
            if (chosenPath != null)
                this.fileNameTbx.Text = chosenPath;
        }

        private void saveAsTxtBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fileNameTbx.Text))
                createAndShowSaveFileDialogForExportingFileName();
            if (!string.IsNullOrEmpty(this.fileNameTbx.Text))
            {
                StudentSignRecordExporter.toTxt(record, this.fileNameTbx.Text);
                MessageBox.Show(" 已匯出成TXT檔案！");
            }

        }

        private void saveAsExcelBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fileNameTbx.Text))
                createAndShowSaveFileDialogForExportingFileName();
            if (!string.IsNullOrEmpty(this.fileNameTbx.Text))
            {
                try
                {
                    StudentSignRecordExporter.toExcel(record, this.fileNameTbx.Text);
                    MessageBox.Show(" 已匯出成EXCEL檔案！");
                }
                catch (Exception err)
                {
                    MessageBox.Show("匯出失敗！請確認電腦上已安裝Excel！");
                }
            }
        }

        private void saveToGoogleSpreadSheetBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
