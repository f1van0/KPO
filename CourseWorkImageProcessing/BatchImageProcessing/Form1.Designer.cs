
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
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.отрытьИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСписокИзображенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПлагинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смотретьСписокФильтровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImagesDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImagesDialog = new System.Windows.Forms.SaveFileDialog();
            this.openPluginDialog = new System.Windows.Forms.OpenFileDialog();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПлагинToolStripMenuItem,
            this.смотретьСписокФильтровToolStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.фильтрToolStripMenuItem.Text = "Фильтр";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(173, 394);
            this.flowLayoutPanel1.TabIndex = 2;
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
            this.pictureBox1.Location = new System.Drawing.Point(179, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 350);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Загрузить изображения";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Обработать изображения";
            this.button1.UseVisualStyleBackColor = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Загружено изображений: 0";
            // 
            // отрытьИзображенияToolStripMenuItem
            // 
            this.отрытьИзображенияToolStripMenuItem.Name = "отрытьИзображенияToolStripMenuItem";
            this.отрытьИзображенияToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.отрытьИзображенияToolStripMenuItem.Text = "Отрыть изображения";
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
            // 
            // добавитьПлагинToolStripMenuItem
            // 
            this.добавитьПлагинToolStripMenuItem.Name = "добавитьПлагинToolStripMenuItem";
            this.добавитьПлагинToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.добавитьПлагинToolStripMenuItem.Text = "Добавить фильтр";
            // 
            // смотретьСписокФильтровToolStripMenuItem
            // 
            this.смотретьСписокФильтровToolStripMenuItem.Name = "смотретьСписокФильтровToolStripMenuItem";
            this.смотретьСписокФильтровToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.смотретьСписокФильтровToolStripMenuItem.Text = "Смотреть список фильтров";
            // 
            // отменитьДействиеToolStripMenuItem
            // 
            this.отменитьДействиеToolStripMenuItem.Name = "отменитьДействиеToolStripMenuItem";
            this.отменитьДействиеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.отменитьДействиеToolStripMenuItem.Text = "Отменить действие";
            // 
            // повторитьДействиеToolStripMenuItem
            // 
            this.повторитьДействиеToolStripMenuItem.Name = "повторитьДействиеToolStripMenuItem";
            this.повторитьДействиеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.повторитьДействиеToolStripMenuItem.Text = "Повторить действие";
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
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // openImagesDialog
            // 
            this.openImagesDialog.FileName = "openFileDialog1";
            // 
            // openPluginDialog
            // 
            this.openPluginDialog.FileName = "openFileDialog1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem отрытьИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьСписокИзображенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПлагинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem смотретьСписокФильтровToolStripMenuItem;
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

