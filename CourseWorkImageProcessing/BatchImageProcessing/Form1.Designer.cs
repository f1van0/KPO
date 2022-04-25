
namespace BatchImageProcessing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отрытьИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСписокИзображенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ПапкиСПлагаминамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СписокПлагиновStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadImagesList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UploadImagesButton = new System.Windows.Forms.Button();
            this.ProcessImagesButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfUploadedImagesLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openImagesDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImagesDialog = new System.Windows.Forms.SaveFileDialog();
            this.openPluginDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрToolStripMenuItem,
            this.изображениеToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отрытьИзображенияToolStripMenuItem,
            this.очиститьСписокИзображенийToolStripMenuItem,
            this.сохранитьИзображенияToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // отрытьИзображенияToolStripMenuItem
            // 
            this.отрытьИзображенияToolStripMenuItem.Name = "отрытьИзображенияToolStripMenuItem";
            this.отрытьИзображенияToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.отрытьИзображенияToolStripMenuItem.Text = "Отрыть изображения";
            this.отрытьИзображенияToolStripMenuItem.Click += new System.EventHandler(this.отрытьИзображенияToolStripMenuItem_Click);
            // 
            // очиститьСписокИзображенийToolStripMenuItem
            // 
            this.очиститьСписокИзображенийToolStripMenuItem.Name = "очиститьСписокИзображенийToolStripMenuItem";
            this.очиститьСписокИзображенийToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.очиститьСписокИзображенийToolStripMenuItem.Text = "Очистить список изображений";
            // 
            // сохранитьИзображенияToolStripMenuItem
            // 
            this.сохранитьИзображенияToolStripMenuItem.Name = "сохранитьИзображенияToolStripMenuItem";
            this.сохранитьИзображенияToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.сохранитьИзображенияToolStripMenuItem.Text = "Сохранить изображения";
            this.сохранитьИзображенияToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображенияToolStripMenuItem_Click);
            // 
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ПапкиСПлагаминамиToolStripMenuItem,
            this.СписокПлагиновStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.фильтрToolStripMenuItem.Text = "Фильтр";
            // 
            // ПапкиСПлагаминамиToolStripMenuItem
            // 
            this.ПапкиСПлагаминамиToolStripMenuItem.Name = "ПапкиСПлагаминамиToolStripMenuItem";
            this.ПапкиСПлагаминамиToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ПапкиСПлагаминамиToolStripMenuItem.Text = "Папки с плагинами";
            this.ПапкиСПлагаминамиToolStripMenuItem.Click += new System.EventHandler(this.ПапкиСПлагаминамиToolStripMenuItem_Click);
            // 
            // СписокПлагиновStripMenuItem
            // 
            this.СписокПлагиновStripMenuItem.Name = "СписокПлагиновStripMenuItem";
            this.СписокПлагиновStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.СписокПлагиновStripMenuItem.Text = "Список плагинов";
            this.СписокПлагиновStripMenuItem.Click += new System.EventHandler(this.ФильрыStripMenuItem_Click);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьДействиеToolStripMenuItem,
            this.повторитьДействиеToolStripMenuItem});
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.изображениеToolStripMenuItem.Text = "Правка";
            // 
            // отменитьДействиеToolStripMenuItem
            // 
            this.отменитьДействиеToolStripMenuItem.Name = "отменитьДействиеToolStripMenuItem";
            this.отменитьДействиеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.отменитьДействиеToolStripMenuItem.Text = "Отменить действие";
            this.отменитьДействиеToolStripMenuItem.Click += new System.EventHandler(this.отменитьДействиеToolStripMenuItem_Click);
            // 
            // повторитьДействиеToolStripMenuItem
            // 
            this.повторитьДействиеToolStripMenuItem.Name = "повторитьДействиеToolStripMenuItem";
            this.повторитьДействиеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.повторитьДействиеToolStripMenuItem.Text = "Повторить действие";
            this.повторитьДействиеToolStripMenuItem.Click += new System.EventHandler(this.повторитьДействиеToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистикаToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // uploadImagesList
            // 
            this.uploadImagesList.AutoScroll = true;
            this.uploadImagesList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uploadImagesList.Location = new System.Drawing.Point(0, 44);
            this.uploadImagesList.Name = "uploadImagesList";
            this.uploadImagesList.Size = new System.Drawing.Size(202, 394);
            this.uploadImagesList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список изображений:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(208, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // UploadImagesButton
            // 
            this.UploadImagesButton.Location = new System.Drawing.Point(426, 188);
            this.UploadImagesButton.Name = "UploadImagesButton";
            this.UploadImagesButton.Size = new System.Drawing.Size(171, 38);
            this.UploadImagesButton.TabIndex = 5;
            this.UploadImagesButton.Text = "Загрузить изображения";
            this.UploadImagesButton.UseVisualStyleBackColor = true;
            this.UploadImagesButton.Click += new System.EventHandler(this.UploadImagesButton_Click);
            // 
            // ProcessImagesButton
            // 
            this.ProcessImagesButton.Location = new System.Drawing.Point(606, 400);
            this.ProcessImagesButton.Name = "ProcessImagesButton";
            this.ProcessImagesButton.Size = new System.Drawing.Size(182, 38);
            this.ProcessImagesButton.TabIndex = 6;
            this.ProcessImagesButton.Text = "Обработать изображения";
            this.ProcessImagesButton.UseVisualStyleBackColor = true;
            this.ProcessImagesButton.Click += new System.EventHandler(this.ProcessImagesButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Обработано изображений: 0/0";
            // 
            // numberOfUploadedImagesLabel
            // 
            this.numberOfUploadedImagesLabel.AutoSize = true;
            this.numberOfUploadedImagesLabel.Location = new System.Drawing.Point(0, 441);
            this.numberOfUploadedImagesLabel.Name = "numberOfUploadedImagesLabel";
            this.numberOfUploadedImagesLabel.Size = new System.Drawing.Size(157, 15);
            this.numberOfUploadedImagesLabel.TabIndex = 8;
            this.numberOfUploadedImagesLabel.Text = "Загружено изображений: 0";
            // 
            // openImagesDialog
            // 
            this.openImagesDialog.FileName = "openFileDialog1";
            // 
            // openPluginDialog
            // 
            this.openPluginDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.numberOfUploadedImagesLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProcessImagesButton);
            this.Controls.Add(this.UploadImagesButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uploadImagesList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Пакетная обработка изображений";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel uploadImagesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button UploadImagesButton;
        private System.Windows.Forms.Button ProcessImagesButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label numberOfUploadedImagesLabel;
        private System.Windows.Forms.ToolStripMenuItem отрытьИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьСписокИзображенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПапкиСПлагаминамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СписокПлагиновStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьДействиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторитьДействиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.OpenFileDialog openImagesDialog;
        private System.Windows.Forms.SaveFileDialog saveImagesDialog;
        private System.Windows.Forms.OpenFileDialog openPluginDialog;
    }
}

