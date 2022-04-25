
namespace BatchImageProcessing
{
    partial class ExportImagesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.amountOfExportingImagesLabel = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeDirectoryButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // amountOfExportingImagesLabel
            // 
            this.amountOfExportingImagesLabel.AutoSize = true;
            this.amountOfExportingImagesLabel.Location = new System.Drawing.Point(13, 22);
            this.amountOfExportingImagesLabel.Name = "amountOfExportingImagesLabel";
            this.amountOfExportingImagesLabel.Size = new System.Drawing.Size(299, 20);
            this.amountOfExportingImagesLabel.TabIndex = 0;
            this.amountOfExportingImagesLabel.Text = "Количество выгружаемых изображений: ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(168, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Исходное название";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Способ наименования изображений:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 124);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(169, 24);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Порядковый номер";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(13, 154);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(324, 24);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Исходное название и порядновый номер";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(13, 239);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(459, 27);
            this.PathTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Путь к папке, в которую экспортируются элементы";
            // 
            // ChangeDirectoryButton
            // 
            this.ChangeDirectoryButton.Location = new System.Drawing.Point(478, 237);
            this.ChangeDirectoryButton.Name = "ChangeDirectoryButton";
            this.ChangeDirectoryButton.Size = new System.Drawing.Size(94, 29);
            this.ChangeDirectoryButton.TabIndex = 7;
            this.ChangeDirectoryButton.Text = "Изменить";
            this.ChangeDirectoryButton.UseVisualStyleBackColor = true;
            this.ChangeDirectoryButton.Click += new System.EventHandler(this.ChangeDirectoryButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(235, 338);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(138, 29);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Экспортировать";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ExportImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 379);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ChangeDirectoryButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.amountOfExportingImagesLabel);
            this.Name = "ExportImagesForm";
            this.Text = "ExportImagesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountOfExportingImagesLabel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChangeDirectoryButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}