namespace KPO_Lab4
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.workersUpDown = new System.Windows.Forms.NumericUpDown();
            this.recBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dbBox = new System.Windows.Forms.TextBox();
            this.recStopBtn = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.filterCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resCombo = new System.Windows.Forms.ComboBox();
            this.filteredBar = new System.Windows.Forms.ProgressBar();
            this.savedBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imageCounterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Остановить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 432);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Пауза";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 424);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 503);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Потоки";
            // 
            // workersUpDown
            // 
            this.workersUpDown.Location = new System.Drawing.Point(478, 503);
            this.workersUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.workersUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.workersUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.workersUpDown.Name = "workersUpDown";
            this.workersUpDown.Size = new System.Drawing.Size(47, 20);
            this.workersUpDown.TabIndex = 12;
            this.workersUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // recBtn
            // 
            this.recBtn.Location = new System.Drawing.Point(618, 496);
            this.recBtn.Margin = new System.Windows.Forms.Padding(2);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(80, 27);
            this.recBtn.TabIndex = 13;
            this.recBtn.Text = "Записать";
            this.recBtn.UseVisualStyleBackColor = true;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // dbBox
            // 
            this.dbBox.Location = new System.Drawing.Point(492, 12);
            this.dbBox.Margin = new System.Windows.Forms.Padding(2);
            this.dbBox.Multiline = true;
            this.dbBox.Name = "dbBox";
            this.dbBox.ReadOnly = true;
            this.dbBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbBox.Size = new System.Drawing.Size(206, 357);
            this.dbBox.TabIndex = 14;
            // 
            // recStopBtn
            // 
            this.recStopBtn.Location = new System.Drawing.Point(533, 496);
            this.recStopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.recStopBtn.Name = "recStopBtn";
            this.recStopBtn.Size = new System.Drawing.Size(81, 27);
            this.recStopBtn.TabIndex = 15;
            this.recStopBtn.Text = "Остановить";
            this.recStopBtn.UseVisualStyleBackColor = true;
            this.recStopBtn.Click += new System.EventHandler(this.recStopBtn_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(332, 387);
            this.pathBox.Margin = new System.Windows.Forms.Padding(2);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.Size = new System.Drawing.Size(282, 20);
            this.pathBox.TabIndex = 16;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(618, 384);
            this.openBtn.Margin = new System.Windows.Forms.Padding(2);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(80, 24);
            this.openBtn.TabIndex = 17;
            this.openBtn.Text = "Изменить";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 411);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Фильтр воспроизведения";
            // 
            // filterCombo
            // 
            this.filterCombo.FormattingEnabled = true;
            this.filterCombo.Location = new System.Drawing.Point(533, 463);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(161, 21);
            this.filterCombo.TabIndex = 19;
            this.filterCombo.SelectedIndexChanged += new System.EventHandler(this.filterCombo_SelectedIndexChanged);
            this.filterCombo.SelectedValueChanged += new System.EventHandler(this.filterCombo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 448);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Разрешение";
            // 
            // resCombo
            // 
            this.resCombo.FormattingEnabled = true;
            this.resCombo.Location = new System.Drawing.Point(93, 463);
            this.resCombo.Name = "resCombo";
            this.resCombo.Size = new System.Drawing.Size(139, 21);
            this.resCombo.TabIndex = 21;
            this.resCombo.SelectedValueChanged += new System.EventHandler(this.resCombo_SelectedValueChanged);
            // 
            // filteredBar
            // 
            this.filteredBar.Location = new System.Drawing.Point(11, 504);
            this.filteredBar.Margin = new System.Windows.Forms.Padding(2);
            this.filteredBar.Name = "filteredBar";
            this.filteredBar.Size = new System.Drawing.Size(184, 19);
            this.filteredBar.TabIndex = 22;
            // 
            // savedBar
            // 
            this.savedBar.Location = new System.Drawing.Point(204, 504);
            this.savedBar.Margin = new System.Windows.Forms.Padding(2);
            this.savedBar.Name = "savedBar";
            this.savedBar.Size = new System.Drawing.Size(184, 19);
            this.savedBar.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 489);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Обработано";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 489);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Записано на диск";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 376);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Ссылка на axis камеру";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 388);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = "http://87.161.102.220:80/mjpg/video.mjpg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 374);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Путь сохранения картинок";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(530, 448);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Фильтр записи";
            // 
            // imageCounterLabel
            // 
            this.imageCounterLabel.AutoSize = true;
            this.imageCounterLabel.Location = new System.Drawing.Point(430, 528);
            this.imageCounterLabel.Name = "imageCounterLabel";
            this.imageCounterLabel.Size = new System.Drawing.Size(193, 13);
            this.imageCounterLabel.TabIndex = 31;
            this.imageCounterLabel.Text = "Поступило картинок на обработку: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 563);
            this.Controls.Add(this.imageCounterLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.savedBar);
            this.Controls.Add(this.filteredBar);
            this.Controls.Add(this.resCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.recStopBtn);
            this.Controls.Add(this.dbBox);
            this.Controls.Add(this.recBtn);
            this.Controls.Add(this.workersUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown workersUpDown;
		private System.Windows.Forms.Button recBtn;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox dbBox;
		private System.Windows.Forms.Button recStopBtn;
		private System.Windows.Forms.TextBox pathBox;
		private System.Windows.Forms.Button openBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox filterCombo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox resCombo;
		private System.Windows.Forms.ProgressBar filteredBar;
		private System.Windows.Forms.ProgressBar savedBar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label imageCounterLabel;
    }
}

