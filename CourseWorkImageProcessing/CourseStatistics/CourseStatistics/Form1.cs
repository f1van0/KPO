using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office;
using Microsoft.Office.Core;
using System.Windows.Forms.DataVisualization.Charting;

namespace CourseStatistics
{
    public partial class Form1 : Form
    {
        public ImagesDB _imagesDB;
        public Excel.Application _excelApp;

        private int _numberOfImages;
        private int uploadImagesAmount;
        private int savedImagesAmount;
        private int averageAppliedFilters;
        private int averageProcessingTime;

        public Form1()
        {
            InitializeComponent();
            _imagesDB = new ImagesDB();
            UpdateInformation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _excelApp = new Excel.Application();
            _excelApp.Workbooks.Add();

            if (_excelApp == null)
            {
                MessageBox.Show("Не удалось воспользоваться средставми Microsoft Excel");
                return;
            }

            Excel.Workbook excelWorkBook;
            Excel.Worksheet excelWorkSheet;
            //System.Reflection.Missing missingValue = System.Reflection.Missing.Value;

            excelWorkBook = _excelApp.ActiveWorkbook;
            excelWorkSheet = (Excel.Worksheet)_excelApp.ActiveSheet;

            //excelWorkBook = excelApp.Workbooks.Add(missingValue);
            //excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.Item[0];

            Bitmap outputChartBitmap = new Bitmap(uploadChartResolutions.Width, uploadChartResolutions.Height);
            uploadChartResolutions.SaveImage($"{Directory.GetCurrentDirectory()}\\chart1.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            saveChartResolutions.SaveImage($"{Directory.GetCurrentDirectory()}\\chart2.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            excelWorkSheet.EnableOutlining = true;

            excelWorkSheet.Cells[8, 1] = "Название";
            excelWorkSheet.Cells[8, 2] = "Разрешение изображения";
            excelWorkSheet.Cells[8, 3] = "Применено фильтров";
            excelWorkSheet.Cells[8, 4] = "Время обработки";
            excelWorkSheet.Cells[8, 5] = "Дата";

            for (int i = 0; i < _numberOfImages; i++)
            {
                excelWorkSheet.Cells[i + 9, 1] = (string)imageItemsDataGrid.Rows[i].Cells[0].Value;
                excelWorkSheet.Cells[i + 9, 2] = (string)imageItemsDataGrid.Rows[i].Cells[1].Value;
                excelWorkSheet.Cells[i + 9, 3] = (string)imageItemsDataGrid.Rows[i].Cells[2].Value;
                excelWorkSheet.Cells[i + 9, 4] = (string)imageItemsDataGrid.Rows[i].Cells[3].Value;
                excelWorkSheet.Cells[i + 9, 5] = (string)imageItemsDataGrid.Rows[i].Cells[4].Value;
            }

            excelWorkSheet.Columns[1].AutoFit();
            excelWorkSheet.Columns[2].AutoFit();
            excelWorkSheet.Columns[3].AutoFit();
            excelWorkSheet.Columns[4].AutoFit();
            excelWorkSheet.Columns[5].AutoFit();

            excelWorkSheet.Cells[1, 1] = "Статистика использования приложения";

            excelWorkSheet.Cells[3, 1] = $"Количество загруженных фотографий: {uploadImagesAmount}";
            excelWorkSheet.Cells[4, 1] = $"Количество сохраненных фотографий: {savedImagesAmount}";
            excelWorkSheet.Cells[5, 1] = $"Среднее количество применяемых фильтров к изображениям: {averageAppliedFilters}";
            excelWorkSheet.Cells[6, 1] = $"Среднее время обработки изображений: {averageProcessingTime}";

            int xPosition = 0;
            for(int i = 0; i < 5; i++)
            {
                xPosition += excelWorkSheet.Columns[1].ColumnWidth;
            }

            excelWorkSheet.Shapes.AddPicture($"{Directory.GetCurrentDirectory()}\\chart1.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 670, 20, uploadChartResolutions.Width, uploadChartResolutions.Height);
            excelWorkSheet.Shapes.AddPicture($"{Directory.GetCurrentDirectory()}\\chart2.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 670, 400, uploadChartResolutions.Width, uploadChartResolutions.Height);

            excelWorkBook.SaveAs($"{Directory.GetCurrentDirectory()}\\test.xls", Excel.XlFileFormat.xlWorkbookNormal);
            //excelWorkBook.SaveAs("test.xls", Excel.XlFileFormat.xlWorkbookNormal, missingValue, missingValue, missingValue, missingValue, Excel.XlSaveAsAccessMode.xlExclusive, missingValue, missingValue, missingValue, missingValue, missingValue);
            //excelWorkBook.Close(true, missingValue, missingValue);
            _excelApp.Quit();

            Marshal.ReleaseComObject(excelWorkSheet);
            Marshal.ReleaseComObject(excelWorkBook);
            Marshal.ReleaseComObject(_excelApp);
            MessageBox.Show(".xls файл со статистикой был создан");
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                _imagesDB = new ImagesDB(path);
                UpdateInformation();
            }
        }

        private void UpdateInformation()
        {
            if (File.Exists("images.db"))
            {
                titleInfoLabel.Text = $"Статистика использования приложения за {File.GetCreationTime("images.db")}";
            }
            _numberOfImages = -1;
            numericUpDown1.Value = 0;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 0;
            UpdateTable();
            UpdateImagesInfo(uploadChartResolutions, 0, Color.OrangeRed);
            UpdateImagesInfo(saveChartResolutions, 1, Color.MediumPurple);

            uploadImagesAmount = ImagesDB.Instance.GetAmountOfImages(0);
            savedImagesAmount = ImagesDB.Instance.GetAmountOfImages(1);
            averageAppliedFilters = ImagesDB.Instance.GetAverageAmountOfFilters();
            averageProcessingTime = ImagesDB.Instance.GetAverageProcessingTime() / 1000;

            uploadImagesAmountLabel.Text = $"Количество загруженных изображений: {uploadImagesAmount}";
            savedImagesAmountLabel.Text = $"Количество сохраненных изображений: {savedImagesAmount}";
            averageAppliedFiltersLabel.Text = $"Среднее количество применяемых фильтров к изображениям: {averageAppliedFilters}";
            averageProcessingTimeLabel.Text = $"Среднее время обработки изображений: {averageProcessingTime} сек.";
        }

        private void UpdateTable()
        {
            List<ImageRow> imageRows = ImagesDB.Instance.SelectWithStatus(1);

            if (_numberOfImages == -1)
            {
                numericUpDown1.Maximum = imageRows.Count;
                numericUpDown1.Value = Math.Min(5, imageRows.Count);
            }

            _numberOfImages = (int)numericUpDown1.Value;

            imageItemsDataGrid.Rows.Clear();
            for (int i= 0; i < _numberOfImages; i++)
            {
                string[] row = { imageRows[i].Name, imageRows[i].Resolution, imageRows[i].AppliedFiltersAmount.ToString(), (imageRows[i].ProcessingTime / 1000).ToString(), imageRows[i].Date.ToString() };
                imageItemsDataGrid.Rows.Add(row);
            }
        }

        private void UpdateImagesInfo(Chart chart, int status, Color color)
        {
            var results = ImagesDB.Instance.SelectResolutionsGradation(status);
            results.Reverse();

            chart.Series[0].Points.Clear();
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart.Series[0].Color = color;
            //chart.Series[0].Font = new Font("Arial", 500);
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            for (int i = 0; i < results.Count && i < 10; i++)
            {
                chart.Series[0].Points.AddXY(results[i].Key, results[i].Value);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
