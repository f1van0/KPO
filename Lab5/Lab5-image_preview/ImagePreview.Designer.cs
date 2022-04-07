namespace Lab5_image_preview
	{
	partial class ImagePreview
		{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose (bool disposing)
			{
			if ( disposing && ( components != null ) )
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
		private void InitializeComponent ()
			{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SecondNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.ThirdNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PasteStructureButton = new System.Windows.Forms.Button();
            this.postText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ApplyFilterButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CopyImageButton = new System.Windows.Forms.Button();
            this.PasteImageButton = new System.Windows.Forms.Button();
            this.PasteTextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Присланное сообщение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Присланная структура:";
            // 
            // SecondNameTextBox
            // 
            this.SecondNameTextBox.Location = new System.Drawing.Point(756, 197);
            this.SecondNameTextBox.Name = "SecondNameTextBox";
            this.SecondNameTextBox.ReadOnly = true;
            this.SecondNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.SecondNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(753, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Имя";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(756, 239);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.ReadOnly = true;
            this.FirstNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.FirstNameTextBox.TabIndex = 5;
            // 
            // ThirdNameTextBox
            // 
            this.ThirdNameTextBox.Location = new System.Drawing.Point(756, 278);
            this.ThirdNameTextBox.Name = "ThirdNameTextBox";
            this.ThirdNameTextBox.ReadOnly = true;
            this.ThirdNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.ThirdNameTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Отчество";
            // 
            // PasteStructureButton
            // 
            this.PasteStructureButton.Location = new System.Drawing.Point(756, 315);
            this.PasteStructureButton.Name = "PasteStructureButton";
            this.PasteStructureButton.Size = new System.Drawing.Size(233, 39);
            this.PasteStructureButton.TabIndex = 9;
            this.PasteStructureButton.Text = "Вставить значения из буфера";
            this.PasteStructureButton.UseVisualStyleBackColor = true;
            this.PasteStructureButton.Click += new System.EventHandler(this.PasteStructureButton_Click);
            // 
            // postText
            // 
            this.postText.AutoSize = true;
            this.postText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postText.Location = new System.Drawing.Point(753, 52);
            this.postText.Name = "postText";
            this.postText.Size = new System.Drawing.Size(64, 20);
            this.postText.TabIndex = 10;
            this.postText.Text = "Ничего";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(38, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 326);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Без фильтра",
            "Инверсия цветов",
            "Оттенки серого",
            "Увеличение яркости"});
            this.comboBox1.Location = new System.Drawing.Point(38, 380);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Без фильтра";
            // 
            // ApplyFilterButton
            // 
            this.ApplyFilterButton.Location = new System.Drawing.Point(233, 364);
            this.ApplyFilterButton.Name = "ApplyFilterButton";
            this.ApplyFilterButton.Size = new System.Drawing.Size(159, 37);
            this.ApplyFilterButton.TabIndex = 12;
            this.ApplyFilterButton.Text = "Применить фильтр";
            this.ApplyFilterButton.UseVisualStyleBackColor = true;
            this.ApplyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Выбор фильтра";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(398, 388);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(188, 13);
            this.timeLabel.TabIndex = 14;
            this.timeLabel.Text = "Применение фильтра заняло: 0 мс.";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(1022, 25);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(332, 395);
            this.logTextBox.TabIndex = 15;
            this.logTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1019, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Записи действий:";
            // 
            // CopyImageButton
            // 
            this.CopyImageButton.Location = new System.Drawing.Point(592, 360);
            this.CopyImageButton.Name = "CopyImageButton";
            this.CopyImageButton.Size = new System.Drawing.Size(159, 27);
            this.CopyImageButton.TabIndex = 17;
            this.CopyImageButton.Text = "Скопировать изображение";
            this.CopyImageButton.UseVisualStyleBackColor = true;
            this.CopyImageButton.Click += new System.EventHandler(this.CopyImageButton_Click);
            // 
            // PasteImageButton
            // 
            this.PasteImageButton.Location = new System.Drawing.Point(592, 393);
            this.PasteImageButton.Name = "PasteImageButton";
            this.PasteImageButton.Size = new System.Drawing.Size(159, 27);
            this.PasteImageButton.TabIndex = 18;
            this.PasteImageButton.Text = "Вставить изображение";
            this.PasteImageButton.UseVisualStyleBackColor = true;
            this.PasteImageButton.Click += new System.EventHandler(this.PasteImageButton_Click);
            // 
            // PasteTextButton
            // 
            this.PasteTextButton.Location = new System.Drawing.Point(753, 84);
            this.PasteTextButton.Name = "PasteTextButton";
            this.PasteTextButton.Size = new System.Drawing.Size(96, 25);
            this.PasteTextButton.TabIndex = 19;
            this.PasteTextButton.Text = "Вставить";
            this.PasteTextButton.UseVisualStyleBackColor = true;
            this.PasteTextButton.Click += new System.EventHandler(this.PasteTextButton_Click);
            // 
            // ImagePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 446);
            this.Controls.Add(this.PasteTextButton);
            this.Controls.Add(this.PasteImageButton);
            this.Controls.Add(this.CopyImageButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ApplyFilterButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.postText);
            this.Controls.Add(this.PasteStructureButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ThirdNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SecondNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(420, 40);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImagePreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagePreview_FormClosing);
            this.Load += new System.EventHandler(this.ImagePreview_Load);
            this.SizeChanged += new System.EventHandler(this.ImagePreview_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SecondNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox ThirdNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button PasteStructureButton;
        private System.Windows.Forms.Label postText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button ApplyFilterButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CopyImageButton;
        private System.Windows.Forms.Button PasteImageButton;
        private System.Windows.Forms.Button PasteTextButton;
    }
	}

