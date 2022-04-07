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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SetImageButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.postTextWM = new System.Windows.Forms.Button();
            this.SendImageSocketButton = new System.Windows.Forms.Button();
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
            this.SendStructureWMButton = new System.Windows.Forms.Button();
            this.SendStructureSocketButton = new System.Windows.Forms.Button();
            this.SendTextSocketButton = new System.Windows.Forms.Button();
            this.SendImageWMButton = new System.Windows.Forms.Button();
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
            // postTextWM
            // 
            this.postTextWM.Location = new System.Drawing.Point(260, 343);
            this.postTextWM.Margin = new System.Windows.Forms.Padding(2);
            this.postTextWM.Name = "postTextWM";
            this.postTextWM.Size = new System.Drawing.Size(142, 25);
            this.postTextWM.TabIndex = 3;
            this.postTextWM.Text = "Отправить текст с WM";
            this.postTextWM.UseVisualStyleBackColor = true;
            this.postTextWM.Click += new System.EventHandler(this.sendTextWM);
            // 
            // SendImageSocketButton
            // 
            this.SendImageSocketButton.Location = new System.Drawing.Point(531, 343);
            this.SendImageSocketButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendImageSocketButton.Name = "SendImageSocketButton";
            this.SendImageSocketButton.Size = new System.Drawing.Size(195, 25);
            this.SendImageSocketButton.TabIndex = 4;
            this.SendImageSocketButton.Text = "Отправить изображение с Socket";
            this.SendImageSocketButton.UseVisualStyleBackColor = true;
            this.SendImageSocketButton.Click += new System.EventHandler(this.sendImageSocket);
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
            this.CopyStructureButton.Location = new System.Drawing.Point(711, 185);
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
            this.PasteStructureButton.Location = new System.Drawing.Point(711, 214);
            this.PasteStructureButton.Margin = new System.Windows.Forms.Padding(2);
            this.PasteStructureButton.Name = "PasteStructureButton";
            this.PasteStructureButton.Size = new System.Drawing.Size(85, 25);
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
            this.CopyImageButton.Size = new System.Drawing.Size(195, 25);
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
            this.CopyText.Size = new System.Drawing.Size(142, 25);
            this.CopyText.TabIndex = 20;
            this.CopyText.Text = "Скопировать текст";
            this.CopyText.UseVisualStyleBackColor = true;
            this.CopyText.Click += new System.EventHandler(this.CopyText_Click);
            // 
            // SendStructureWMButton
            // 
            this.SendStructureWMButton.Location = new System.Drawing.Point(631, 185);
            this.SendStructureWMButton.Name = "SendStructureWMButton";
            this.SendStructureWMButton.Size = new System.Drawing.Size(75, 39);
            this.SendStructureWMButton.TabIndex = 21;
            this.SendStructureWMButton.Text = "Отправить с WM";
            this.SendStructureWMButton.UseVisualStyleBackColor = true;
            this.SendStructureWMButton.Click += new System.EventHandler(this.sendStructureWM);
            // 
            // SendStructureSocketButton
            // 
            this.SendStructureSocketButton.Location = new System.Drawing.Point(801, 185);
            this.SendStructureSocketButton.Name = "SendStructureSocketButton";
            this.SendStructureSocketButton.Size = new System.Drawing.Size(75, 39);
            this.SendStructureSocketButton.TabIndex = 22;
            this.SendStructureSocketButton.Text = "Отправить с Socket";
            this.SendStructureSocketButton.UseVisualStyleBackColor = true;
            this.SendStructureSocketButton.Click += new System.EventHandler(this.sendStructureSocket);
            // 
            // SendTextSocketButton
            // 
            this.SendTextSocketButton.Location = new System.Drawing.Point(260, 373);
            this.SendTextSocketButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendTextSocketButton.Name = "SendTextSocketButton";
            this.SendTextSocketButton.Size = new System.Drawing.Size(142, 45);
            this.SendTextSocketButton.TabIndex = 23;
            this.SendTextSocketButton.Text = "Отправить текст с Socket";
            this.SendTextSocketButton.UseVisualStyleBackColor = true;
            this.SendTextSocketButton.Click += new System.EventHandler(this.sendTextSocket);
            // 
            // SendImageWMButton
            // 
            this.SendImageWMButton.Location = new System.Drawing.Point(529, 372);
            this.SendImageWMButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendImageWMButton.Name = "SendImageWMButton";
            this.SendImageWMButton.Size = new System.Drawing.Size(197, 25);
            this.SendImageWMButton.TabIndex = 24;
            this.SendImageWMButton.Text = "Отправить изображение с WM";
            this.SendImageWMButton.UseVisualStyleBackColor = true;
            this.SendImageWMButton.Click += new System.EventHandler(this.sendImageWM);
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 429);
            this.Controls.Add(this.SendImageWMButton);
            this.Controls.Add(this.SendTextSocketButton);
            this.Controls.Add(this.SendStructureSocketButton);
            this.Controls.Add(this.SendStructureWMButton);
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
            this.Controls.Add(this.SendImageSocketButton);
            this.Controls.Add(this.postTextWM);
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

		private System.Windows.Forms.Button SendStructureWMButton;

		#endregion

		private System.Windows.Forms.Button SetImageButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button postTextWM;
        private System.Windows.Forms.Button SendImageSocketButton;
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
        private System.Windows.Forms.Button SendStructureSocketButton;
        private System.Windows.Forms.Button SendTextSocketButton;
        private System.Windows.Forms.Button SendImageWMButton;
    }
	}

