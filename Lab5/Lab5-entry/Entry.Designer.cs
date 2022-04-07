namespace Lab5_entry
	{
	partial class Entry
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
            this.SetImageButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PostTextButton = new System.Windows.Forms.Button();
            this.SendImageButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ThirdNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SecondNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CopyStructureButton = new System.Windows.Forms.Button();
            this.PasteStructureButton = new System.Windows.Forms.Button();
            this.CopyImageButton = new System.Windows.Forms.Button();
            this.CopyText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SetImageButton
            // 
            this.SetImageButton.Location = new System.Drawing.Point(433, 314);
            this.SetImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.SetImageButton.Name = "SetImageButton";
            this.SetImageButton.Size = new System.Drawing.Size(94, 54);
            this.SetImageButton.TabIndex = 0;
            this.SetImageButton.Text = "Изменить изображение";
            this.SetImageButton.UseVisualStyleBackColor = true;
            this.SetImageButton.Click += new System.EventHandler(this.SetImageButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PostTextButton
            // 
            this.PostTextButton.Location = new System.Drawing.Point(260, 343);
            this.PostTextButton.Margin = new System.Windows.Forms.Padding(2);
            this.PostTextButton.Name = "PostTextButton";
            this.PostTextButton.Size = new System.Drawing.Size(131, 25);
            this.PostTextButton.TabIndex = 3;
            this.PostTextButton.Text = "Отправить текст";
            this.PostTextButton.UseVisualStyleBackColor = true;
            this.PostTextButton.Click += new System.EventHandler(this.postTextButton_Click);
            // 
            // SendImageButton
            // 
            this.SendImageButton.Location = new System.Drawing.Point(531, 343);
            this.SendImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendImageButton.Name = "SendImageButton";
            this.SendImageButton.Size = new System.Drawing.Size(153, 25);
            this.SendImageButton.TabIndex = 4;
            this.SendImageButton.Text = "Отправить изображение";
            this.SendImageButton.UseVisualStyleBackColor = true;
            this.SendImageButton.Click += new System.EventHandler(this.SendImageButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 348);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Передаваемое сообщение";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(613, 297);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(628, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Отчество";
            // 
            // ThirdNameTextBox
            // 
            this.ThirdNameTextBox.Location = new System.Drawing.Point(631, 149);
            this.ThirdNameTextBox.Name = "ThirdNameTextBox";
            this.ThirdNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.ThirdNameTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(628, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Имя";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(631, 110);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.FirstNameTextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Фамилия";
            // 
            // SecondNameTextBox
            // 
            this.SecondNameTextBox.Location = new System.Drawing.Point(631, 68);
            this.SecondNameTextBox.Name = "SecondNameTextBox";
            this.SecondNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.SecondNameTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Копируемая структура структура:";
            // 
            // CopyStructureButton
            // 
            this.CopyStructureButton.Location = new System.Drawing.Point(705, 185);
            this.CopyStructureButton.Margin = new System.Windows.Forms.Padding(2);
            this.CopyStructureButton.Name = "CopyStructureButton";
            this.CopyStructureButton.Size = new System.Drawing.Size(85, 25);
            this.CopyStructureButton.TabIndex = 16;
            this.CopyStructureButton.Text = "Скопировать";
            this.CopyStructureButton.UseVisualStyleBackColor = true;
            this.CopyStructureButton.Click += new System.EventHandler(this.CopyStructureButton_Click);
            // 
            // PasteStructureButton
            // 
            this.PasteStructureButton.Location = new System.Drawing.Point(794, 185);
            this.PasteStructureButton.Margin = new System.Windows.Forms.Padding(2);
            this.PasteStructureButton.Name = "PasteStructureButton";
            this.PasteStructureButton.Size = new System.Drawing.Size(67, 25);
            this.PasteStructureButton.TabIndex = 17;
            this.PasteStructureButton.Text = "Вставить";
            this.PasteStructureButton.UseVisualStyleBackColor = true;
            this.PasteStructureButton.Click += new System.EventHandler(this.PasteStructureButton_Click);
            // 
            // CopyImageButton
            // 
            this.CopyImageButton.Location = new System.Drawing.Point(531, 314);
            this.CopyImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.CopyImageButton.Name = "CopyImageButton";
            this.CopyImageButton.Size = new System.Drawing.Size(153, 25);
            this.CopyImageButton.TabIndex = 19;
            this.CopyImageButton.Text = "Скопировать изображение";
            this.CopyImageButton.UseVisualStyleBackColor = true;
            this.CopyImageButton.Click += new System.EventHandler(this.CopyImageButton_Click);
            // 
            // CopyText
            // 
            this.CopyText.Location = new System.Drawing.Point(260, 314);
            this.CopyText.Margin = new System.Windows.Forms.Padding(2);
            this.CopyText.Name = "CopyText";
            this.CopyText.Size = new System.Drawing.Size(131, 25);
            this.CopyText.TabIndex = 20;
            this.CopyText.Text = "Скопировать текст";
            this.CopyText.UseVisualStyleBackColor = true;
            this.CopyText.Click += new System.EventHandler(this.CopyText_Click);
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 379);
            this.Controls.Add(this.CopyText);
            this.Controls.Add(this.CopyImageButton);
            this.Controls.Add(this.PasteStructureButton);
            this.Controls.Add(this.CopyStructureButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ThirdNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SecondNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendImageButton);
            this.Controls.Add(this.PostTextButton);
            this.Controls.Add(this.SetImageButton);
            this.Location = new System.Drawing.Point(100, 40);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Entry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Entry";
            this.Load += new System.EventHandler(this.Entry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Button SetImageButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button PostTextButton;
        private System.Windows.Forms.Button SendImageButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ThirdNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SecondNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CopyStructureButton;
        private System.Windows.Forms.Button PasteStructureButton;
        private System.Windows.Forms.Button CopyImageButton;
        private System.Windows.Forms.Button CopyText;
    }
	}

