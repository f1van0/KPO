namespace CourseStatistics
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.uploadChartResolutions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.titleInfoLabel = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.savedImagesAmountLabel = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uploadImagesAmountLabel = new System.Windows.Forms.Label();
            this.saveChartResolutions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.averageAppliedFiltersLabel = new System.Windows.Forms.Label();
            this.averageProcessingTimeLabel = new System.Windows.Forms.Label();
            this.imageItemsDataGrid = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtersApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uploadChartResolutions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveChartResolutions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageItemsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadChartResolutions
            // 
            chartArea5.Name = "ChartArea1";
            this.uploadChartResolutions.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.uploadChartResolutions.Legends.Add(legend5);
            this.uploadChartResolutions.Location = new System.Drawing.Point(7, 36);
            this.uploadChartResolutions.Name = "uploadChartResolutions";
            series5.ChartArea = "ChartArea1";
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            dataPoint13.BorderWidth = 1;
            dataPoint13.MarkerSize = 5;
            series5.Points.Add(dataPoint13);
            series5.Points.Add(dataPoint14);
            series5.Points.Add(dataPoint15);
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.uploadChartResolutions.Series.Add(series5);
            this.uploadChartResolutions.Size = new System.Drawing.Size(886, 328);
            this.uploadChartResolutions.TabIndex = 0;
            this.uploadChartResolutions.Text = "chart1";
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            title5.Name = "Title1";
            title5.Text = "Градация популярности разрешений у загруженных изображений:";
            this.uploadChartResolutions.Titles.Add(title5);
            this.uploadChartResolutions.Click += new System.EventHandler(this.chart1_Click);
            // 
            // titleInfoLabel
            // 
            this.titleInfoLabel.AutoSize = true;
            this.titleInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.titleInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.titleInfoLabel.Name = "titleInfoLabel";
            this.titleInfoLabel.Size = new System.Drawing.Size(563, 26);
            this.titleInfoLabel.TabIndex = 1;
            this.titleInfoLabel.Text = "Статистика использования приложения за 20.05.2022";
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(97, 38);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 2;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // savedImagesAmountLabel
            // 
            this.savedImagesAmountLabel.AutoSize = true;
            this.savedImagesAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.savedImagesAmountLabel.Location = new System.Drawing.Point(4, 8);
            this.savedImagesAmountLabel.Name = "savedImagesAmountLabel";
            this.savedImagesAmountLabel.Size = new System.Drawing.Size(364, 20);
            this.savedImagesAmountLabel.TabIndex = 5;
            this.savedImagesAmountLabel.Text = "Количество сохраненных фотографий: 86";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(13, 38);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // uploadImagesAmountLabel
            // 
            this.uploadImagesAmountLabel.AutoSize = true;
            this.uploadImagesAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.uploadImagesAmountLabel.Location = new System.Drawing.Point(3, 9);
            this.uploadImagesAmountLabel.Name = "uploadImagesAmountLabel";
            this.uploadImagesAmountLabel.Size = new System.Drawing.Size(373, 20);
            this.uploadImagesAmountLabel.TabIndex = 7;
            this.uploadImagesAmountLabel.Text = "Количество загруженных фотографий: 113";
            // 
            // saveChartResolutions
            // 
            chartArea6.Name = "ChartArea1";
            this.saveChartResolutions.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.saveChartResolutions.Legends.Add(legend6);
            this.saveChartResolutions.Location = new System.Drawing.Point(8, 80);
            this.saveChartResolutions.Name = "saveChartResolutions";
            series6.ChartArea = "ChartArea1";
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            dataPoint16.BorderWidth = 1;
            dataPoint16.MarkerSize = 5;
            series6.Points.Add(dataPoint16);
            series6.Points.Add(dataPoint17);
            series6.Points.Add(dataPoint18);
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.saveChartResolutions.Series.Add(series6);
            this.saveChartResolutions.Size = new System.Drawing.Size(886, 328);
            this.saveChartResolutions.TabIndex = 8;
            this.saveChartResolutions.Text = "chart2";
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            title6.Name = "Title1";
            title6.Text = "Градация популярности разрешений у сохраненных изображений:";
            this.saveChartResolutions.Titles.Add(title6);
            // 
            // averageAppliedFiltersLabel
            // 
            this.averageAppliedFiltersLabel.AutoSize = true;
            this.averageAppliedFiltersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.averageAppliedFiltersLabel.Location = new System.Drawing.Point(4, 28);
            this.averageAppliedFiltersLabel.Name = "averageAppliedFiltersLabel";
            this.averageAppliedFiltersLabel.Size = new System.Drawing.Size(364, 20);
            this.averageAppliedFiltersLabel.TabIndex = 9;
            this.averageAppliedFiltersLabel.Text = "Количество сохраненных фотографий: 86";
            // 
            // averageProcessingTimeLabel
            // 
            this.averageProcessingTimeLabel.AutoSize = true;
            this.averageProcessingTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.averageProcessingTimeLabel.Location = new System.Drawing.Point(4, 48);
            this.averageProcessingTimeLabel.Name = "averageProcessingTimeLabel";
            this.averageProcessingTimeLabel.Size = new System.Drawing.Size(364, 20);
            this.averageProcessingTimeLabel.TabIndex = 10;
            this.averageProcessingTimeLabel.Text = "Количество сохраненных фотографий: 86";
            // 
            // imageItemsDataGrid
            // 
            this.imageItemsDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.imageItemsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageItemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imageItemsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.resolution,
            this.filtersApplied,
            this.processingTime,
            this.date});
            this.imageItemsDataGrid.Location = new System.Drawing.Point(7, 84);
            this.imageItemsDataGrid.Name = "imageItemsDataGrid";
            this.imageItemsDataGrid.ReadOnly = true;
            this.imageItemsDataGrid.RowHeadersWidth = 51;
            this.imageItemsDataGrid.Size = new System.Drawing.Size(551, 726);
            this.imageItemsDataGrid.TabIndex = 11;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // resolution
            // 
            this.resolution.HeaderText = "Разрешение изображения";
            this.resolution.MinimumWidth = 6;
            this.resolution.Name = "resolution";
            this.resolution.ReadOnly = true;
            this.resolution.Width = 125;
            // 
            // filtersApplied
            // 
            this.filtersApplied.HeaderText = "Применено фильтров";
            this.filtersApplied.MinimumWidth = 6;
            this.filtersApplied.Name = "filtersApplied";
            this.filtersApplied.ReadOnly = true;
            this.filtersApplied.Width = 125;
            // 
            // processingTime
            // 
            this.processingTime.HeaderText = "Время обработки";
            this.processingTime.MinimumWidth = 6;
            this.processingTime.Name = "processingTime";
            this.processingTime.ReadOnly = true;
            this.processingTime.Width = 125;
            // 
            // date
            // 
            this.date.HeaderText = "Дата";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Вывод последних n обработанных изображений";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 58);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Количество изображений";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.imageItemsDataGrid);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 819);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uploadImagesAmountLabel);
            this.panel2.Controls.Add(this.uploadChartResolutions);
            this.panel2.Location = new System.Drawing.Point(605, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 377);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.averageAppliedFiltersLabel);
            this.panel3.Controls.Add(this.savedImagesAmountLabel);
            this.panel3.Controls.Add(this.averageProcessingTimeLabel);
            this.panel3.Controls.Add(this.saveChartResolutions);
            this.panel3.Location = new System.Drawing.Point(605, 475);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(901, 416);
            this.panel3.TabIndex = 17;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "report";
            this.saveFileDialog1.Filter = "Excel таблица |*.xls";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 902);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.titleInfoLabel);
            this.Name = "Form1";
            this.Text = "Статистика для приложения BatchImageProcessing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uploadChartResolutions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveChartResolutions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageItemsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart uploadChartResolutions;
        private System.Windows.Forms.Label titleInfoLabel;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label savedImagesAmountLabel;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label uploadImagesAmountLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart saveChartResolutions;
        private System.Windows.Forms.Label averageAppliedFiltersLabel;
        private System.Windows.Forms.Label averageProcessingTimeLabel;
        private System.Windows.Forms.DataGridView imageItemsDataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn resolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn filtersApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn processingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

