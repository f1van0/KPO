
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportImagesForm));
            this.amountOfExportingImagesLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeDirectoryButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.exportNameTextBox = new System.Windows.Forms.TextBox();
            this.imageNameButton = new System.Windows.Forms.Button();
            this.orderNumberButton = new System.Windows.Forms.Button();
            this.exportDateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // amountOfExportingImagesLabel
            // 
            this.amountOfExportingImagesLabel.AutoSize = true;
            this.amountOfExportingImagesLabel.Location = new System.Drawing.Point(13, 21);
            this.amountOfExportingImagesLabel.Name = "amountOfExportingImagesLabel";
            this.amountOfExportingImagesLabel.Size = new System.Drawing.Size(299, 20);
            this.amountOfExportingImagesLabel.TabIndex = 0;
            this.amountOfExportingImagesLabel.Text = "Количество выгружаемых изображений: ";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(7, 289);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(361, 27);
            this.PathTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Путь к папке, в которую сохраняются элементы";
            // 
            // ChangeDirectoryButton
            // 
            this.ChangeDirectoryButton.Location = new System.Drawing.Point(378, 287);
            this.ChangeDirectoryButton.Name = "ChangeDirectoryButton";
            this.ChangeDirectoryButton.Size = new System.Drawing.Size(94, 29);
            this.ChangeDirectoryButton.TabIndex = 7;
            this.ChangeDirectoryButton.Text = "Изменить";
            this.ChangeDirectoryButton.UseVisualStyleBackColor = true;
            this.ChangeDirectoryButton.Click += new System.EventHandler(this.ChangeDirectoryButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(230, 345);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(138, 29);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Экспортировать";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Строка формирующая название для изображения";
            // 
            // exportNameTextBox
            // 
            this.exportNameTextBox.Location = new System.Drawing.Point(13, 88);
            this.exportNameTextBox.Name = "exportNameTextBox";
            this.exportNameTextBox.Size = new System.Drawing.Size(459, 27);
            this.exportNameTextBox.TabIndex = 13;
            this.exportNameTextBox.Text = "%Number%. %Name%.png";
            // 
            // imageNameButton
            // 
            this.imageNameButton.Location = new System.Drawing.Point(14, 125);
            this.imageNameButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imageNameButton.Name = "imageNameButton";
            this.imageNameButton.Size = new System.Drawing.Size(234, 31);
            this.imageNameButton.TabIndex = 14;
            this.imageNameButton.Text = "Добавить название изображения";
            this.imageNameButton.UseVisualStyleBackColor = true;
            this.imageNameButton.Click += new System.EventHandler(this.imageNameButton_Click);
            // 
            // orderNumberButton
            // 
            this.orderNumberButton.Location = new System.Drawing.Point(14, 164);
            this.orderNumberButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.orderNumberButton.Name = "orderNumberButton";
            this.orderNumberButton.Size = new System.Drawing.Size(234, 31);
            this.orderNumberButton.TabIndex = 15;
            this.orderNumberButton.Text = "Добавить порядковый номер";
            this.orderNumberButton.UseVisualStyleBackColor = true;
            this.orderNumberButton.Click += new System.EventHandler(this.orderNumberButton_Click);
            // 
            // exportDateButton
            // 
            this.exportDateButton.Location = new System.Drawing.Point(14, 203);
            this.exportDateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportDateButton.Name = "exportDateButton";
            this.exportDateButton.Size = new System.Drawing.Size(234, 31);
            this.exportDateButton.TabIndex = 16;
            this.exportDateButton.Text = "Добавить дату экспорта";
            this.exportDateButton.UseVisualStyleBackColor = true;
            this.exportDateButton.Click += new System.EventHandler(this.exportDateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(487, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(417, 242);
            this.label2.TabIndex = 17;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // ExportImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 389);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exportDateButton);
            this.Controls.Add(this.orderNumberButton);
            this.Controls.Add(this.imageNameButton);
            this.Controls.Add(this.exportNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ChangeDirectoryButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.amountOfExportingImagesLabel);
            this.Name = "ExportImagesForm";
            this.Text = "ExportImagesForm";
            this.Load += new System.EventHandler(this.ExportImagesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountOfExportingImagesLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChangeDirectoryButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exportNameTextBox;
        private System.Windows.Forms.Button imageNameButton;
        private System.Windows.Forms.Button orderNumberButton;
        private System.Windows.Forms.Button exportDateButton;
        private System.Windows.Forms.Label label2;
    }
}