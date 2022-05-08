﻿
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
            this.лицензияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активироватьЛицензиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UploadImagesButton = new System.Windows.Forms.Button();
            this.ProcessImagesButton = new System.Windows.Forms.Button();
            this.processedImagesCounterLabel = new System.Windows.Forms.Label();
            this.numberOfUploadedImagesLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openImagesDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImagesDialog = new System.Windows.Forms.SaveFileDialog();
            this.openPluginDialog = new System.Windows.Forms.OpenFileDialog();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.processProgressBar = new System.Windows.Forms.ProgressBar();
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
            this.лицензияToolStripMenuItem});
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
            this.отменитьДействиеToolStripMenuItem.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // повторитьДействиеToolStripMenuItem
            // 
            this.повторитьДействиеToolStripMenuItem.Name = "повторитьДействиеToolStripMenuItem";
            this.повторитьДействиеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.повторитьДействиеToolStripMenuItem.Text = "Повторить действие";
            this.повторитьДействиеToolStripMenuItem.Click += new System.EventHandler(this.RedoButton_Click);
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
            // лицензияToolStripMenuItem
            // 
            this.лицензияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.активироватьЛицензиюToolStripMenuItem,
            this.информацияToolStripMenuItem});
            this.лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            this.лицензияToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.лицензияToolStripMenuItem.Text = "Лицензия";
            // 
            // активироватьЛицензиюToolStripMenuItem
            // 
            this.активироватьЛицензиюToolStripMenuItem.Name = "активироватьЛицензиюToolStripMenuItem";
            this.активироватьЛицензиюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.активироватьЛицензиюToolStripMenuItem.Text = "Активировать";
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
            // 
            // imagesList
            // 
            this.imagesList.AutoScroll = true;
            this.imagesList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imagesList.Location = new System.Drawing.Point(0, 44);
            this.imagesList.Name = "imagesList";
            this.imagesList.Size = new System.Drawing.Size(218, 394);
            this.imagesList.TabIndex = 2;
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
            this.pictureBox1.Location = new System.Drawing.Point(224, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UploadImagesButton
            // 
            this.UploadImagesButton.Location = new System.Drawing.Point(433, 200);
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
            // processedImagesCounterLabel
            // 
            this.processedImagesCounterLabel.AutoSize = true;
            this.processedImagesCounterLabel.Location = new System.Drawing.Point(606, 453);
            this.processedImagesCounterLabel.Name = "processedImagesCounterLabel";
            this.processedImagesCounterLabel.Size = new System.Drawing.Size(176, 15);
            this.processedImagesCounterLabel.TabIndex = 7;
            this.processedImagesCounterLabel.Text = "Обработано изображений: 0/0";
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
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(224, 400);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(147, 56);
            this.UndoButton.TabIndex = 9;
            this.UndoButton.Text = "Отменить действие";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(377, 400);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(147, 56);
            this.RedoButton.TabIndex = 10;
            this.RedoButton.Text = "Повторить действие";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // processProgressBar
            // 
            this.processProgressBar.Location = new System.Drawing.Point(606, 471);
            this.processProgressBar.Name = "processProgressBar";
            this.processProgressBar.Size = new System.Drawing.Size(182, 14);
            this.processProgressBar.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.processProgressBar);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.numberOfUploadedImagesLabel);
            this.Controls.Add(this.processedImagesCounterLabel);
            this.Controls.Add(this.ProcessImagesButton);
            this.Controls.Add(this.UploadImagesButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imagesList);
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
        private System.Windows.Forms.FlowLayoutPanel imagesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button UploadImagesButton;
        private System.Windows.Forms.Button ProcessImagesButton;
        private System.Windows.Forms.Label processedImagesCounterLabel;
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
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.OpenFileDialog openImagesDialog;
        private System.Windows.Forms.SaveFileDialog saveImagesDialog;
        private System.Windows.Forms.OpenFileDialog openPluginDialog;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.ProgressBar processProgressBar;
        private System.Windows.Forms.ToolStripMenuItem лицензияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem активироватьЛицензиюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
    }
}

